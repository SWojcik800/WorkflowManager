using StorageManager.App.Features.Dictionaries;
using StorageManager.App.Features.Users;
using StorageManager.App.Helpers;
using StorageManager.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkflowManager.App.Features.UserWorkflows;
using WorkflowManager.App.Forms.Base;
using WorkflowManager.App.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WorkflowManager.App.Forms
{
    public partial class UserWorkflowForm : AppFormBase
    {
        private IUserWorkflowService _service = AppManager.Instance.Resolve<IUserWorkflowService>();
        private IUserService _userService = AppManager.Instance.Resolve<IUserService>();
        private IDataDictionaryService _dictService = AppManager.Instance.Resolve<IDataDictionaryService>();
        private UserWorkflow _data;
        private List<AttachmentDto> _attachments = new List<AttachmentDto>();
        private bool _isReadOnly = false;
        private string _apiBaseurl = AppManager.ApiUrl;

        private Dictionary<string, Func<string>> _getValueFuncs = new Dictionary<string, Func<string>>();
        private Dictionary<string, Func<bool>> _validateDataFuncs = new Dictionary<string, Func<bool>>();
        protected UserWorkflowForm(int id)
        {
            InitializeComponent();
            InitForm();
            _data = _service.GetById(id);

            this.Text = $"{_data.Id}/{_data.Workflow.Name}/{_data.CurrentStage.Name}";
            this.userHistoryEntryReadModelBindingSource.DataSource = _data.HistoryEntries.Select(x => new UserHistoryEntryReadModel(x)).OrderByDescending(x => x.ActionDate).ToList();
            this.appGridView1.DataSource = this.userHistoryEntryReadModelBindingSource;
            this.attachmentDtoBindingSource.DataSource = _attachments;
            this.appGridView2.DataSource = this.attachmentDtoBindingSource;
            this.appGridView2.MultiSelect = true;
            InitFields();
            RefreshAttachmentsFromApi(_data.Id);
        }

        private void AddBearerToken(HttpClient httpClient, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }
        private void RefreshAttachmentsFromApi(int userWorkflowId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var currentUser = AppManager.Instance.CurrentUser;
                    var client = new swaggerClient(_apiBaseurl, httpClient);
                    var result = client.UsersAsync(currentUser.Login, EncryptionHelper.Decrypt(currentUser.Password)).Result;
                    var token = result.Value;
                    AddBearerToken(httpClient, token);
                    var attachmentDtos = client.ForOwnerAsync(userWorkflowId, AttachmentOwnerType._1).Result
                        .OrderByDescending(x => x.CreationTime)
                        .ToList();
                    _attachments.Clear();
                    _attachments.AddRange(attachmentDtos);
                    this.attachmentDtoBindingSource.ResetBindings(true);
                }
            }
            catch (Exception e)
            {

                AppManager.ShowErrorMessage("Bład podczas łączenia z sieciową usługą plików");
            }
        }

        private void DownloadFilesFromApi(List<string> fileIds)
        {
            var folderDialog = new FolderBrowserDialog();

            var result = folderDialog.ShowDialog() == DialogResult.OK;

            if (result)
            {
                var folderPath = folderDialog.SelectedPath;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    using (var httpClient = new HttpClient())
                    {

                        var currentUser = AppManager.Instance.CurrentUser;
                        var client = new swaggerClient(_apiBaseurl, httpClient);
                        var apiResult = client.UsersAsync(currentUser.Login, EncryptionHelper.Decrypt(currentUser.Password)).Result;
                        var token = apiResult.Value;
                        AddBearerToken(httpClient, token);

                        foreach (var id in fileIds)
                        {
                            var file = client.AttachmentsGETAsync(id).Result;

                            var filePath = Path.Combine(folderPath, file.FileName);

                            File.WriteAllBytes(filePath, file.File);
                        }



                    }

                    Process.Start("explorer", folderPath);

                }
                catch (Exception e)
                {

                    AppManager.ShowErrorMessage("Bład podczas łączenia z sieciową usługą plików");
                }
                Cursor.Current = Cursors.Default;

            }

        }

        private async void UploadFile()
        {
            var dialog = new OpenFileDialog();

            var dialogResult = dialog.ShowDialog() == DialogResult.OK;

            if(dialogResult)
            {
                var bytes = File.ReadAllBytes(dialog.FileName);
                var fileName = Path.GetFileName(dialog.FileName);

                try
                {
                    using (var httpClient = new HttpClient())
                {
                    var currentUser = AppManager.Instance.CurrentUser;
                    var client = new swaggerClient(_apiBaseurl, httpClient);
                    var result = client.UsersAsync(currentUser.Login, EncryptionHelper.Decrypt(currentUser.Password)).Result;
                    var token = result.Value;
                    AddBearerToken(httpClient, token);
                    
                    if(_attachments.Any(x => x.FileName == fileName))
                    {
                        AppManager.ShowErrorMessage($"Plik o nazwie {fileName} istnieje już w ramach tego przepływu. Prześlij plik z inną nazwą.");
                        return;
                    }

                    await client.AttachmentsPOSTAsync(new UploadAttachmentDto()
                    {
                        FileName = fileName,
                        OwnerId = _data.Id,
                        AttachmentOwnerType = AttachmentOwnerType._1,
                        Attachment = bytes
                    });

                    RefreshAttachmentsFromApi(_data.Id);
                }
                }
                catch (Exception e)
                {

                    AppManager.ShowErrorMessage("Bład podczas łączenia z sieciową usługą plików");
                }
            }
        }
        private void InitFields()
        {
            var flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;

            this.tabPage1.Controls.Add(flowLayoutPanel);

            foreach (var stageField in _data.CurrentStage.StageFields)
            {
                var fieldDef = _data.Workflow.WorkflowFields.FirstOrDefault(x => x.Code == stageField.FieldCode);

                if (fieldDef is null)
                    continue;

                var isVisible = stageField.IsVisible;
                var isEditable = stageField.IsEditable && !_isReadOnly;
                var isRequired = stageField.IsRequired;
                var label = new Label();
                label.Text = fieldDef.DisplayName + ":";
                var skipLabel = false;

                Control controlToAdd = null;

                switch (fieldDef.Type)
                {
                    case WorkflowFieldType.Text:
                        {
                            var textBox = new System.Windows.Forms.TextBox();
                            textBox.Name = fieldDef.Code;
                            textBox.ReadOnly = !isEditable;


                            _getValueFuncs.Add(fieldDef.Code, () =>
                            {
                                return textBox.Text;
                            });

                            if (isRequired)
                                _validateDataFuncs.Add(fieldDef.Code, () =>
                                {
                                    var text = textBox.Text;
                                    if (string.IsNullOrEmpty(text))
                                    {
                                        this.errorProvider1.SetError(textBox, "To pole jest wymagane");
                                        return false;
                                    }

                                    return true;
                                });

                            var existingValue = _data.UserWorkflowFieldValues.FirstOrDefault(x => x.FieldCode == stageField.FieldCode);
                            if (existingValue is not null)
                                textBox.Text = existingValue.FieldValue;

                            controlToAdd = textBox;
                        }
                        break;
                    case WorkflowFieldType.Checkbox:
                        {
                            var checkbox = new System.Windows.Forms.CheckBox();
                            checkbox.Name = fieldDef.Code;
                            checkbox.Text = fieldDef.DisplayName;
                            skipLabel = true;

                            _getValueFuncs.Add(fieldDef.Code, () =>
                            {
                                return checkbox.Checked.ToString().ToLower().Trim();
                            });

                            var existingValue = _data.UserWorkflowFieldValues.FirstOrDefault(x => x.FieldCode == stageField.FieldCode);
                            if (existingValue is not null)
                                checkbox.Checked = existingValue.FieldValue.ToString() == "true";

                            controlToAdd = checkbox;
                        }
                        break;
                    case WorkflowFieldType.ComboBox:
                        {
                            var comboBox = new System.Windows.Forms.ComboBox();
                            comboBox.Name = fieldDef.Code;
                            //comboBox.Text = fieldDef.DisplayName;

                            object[] items = fieldDef.DisplayData.Split(";").ToArray();
                            comboBox.Items.AddRange(items);

                            _getValueFuncs.Add(fieldDef.Code, () =>
                            {
                                var selectedItem = comboBox.SelectedItem;
                                if (selectedItem == null)
                                    return "";

                                if (string.IsNullOrEmpty(selectedItem.ToString()))
                                    return "";

                                return selectedItem.ToString();
                            });

                            if (isRequired)
                                _validateDataFuncs.Add(fieldDef.Code, () =>
                                {
                                    if (comboBox.SelectedItem is null)
                                    {
                                        this.errorProvider1.SetError(comboBox, "To pole jest wymagane");
                                        return false;
                                    }

                                    var selectedItem = comboBox.SelectedItem.ToString();
                                    if (string.IsNullOrEmpty(selectedItem))
                                    {
                                        this.errorProvider1.SetError(comboBox, "To pole jest wymagane");
                                        return false;
                                    }

                                    return true;
                                });

                            var existingValue = _data.UserWorkflowFieldValues.FirstOrDefault(x => x.FieldCode == stageField.FieldCode);
                            if (existingValue is not null)
                                comboBox.SelectedItem = existingValue.FieldValue;
                            controlToAdd = comboBox;
                        }
                        break;
                    case WorkflowFieldType.Dictionary:
                        {
                            var comboBox = new System.Windows.Forms.ComboBox();
                            comboBox.Name = fieldDef.Code;
                            comboBox.Text = fieldDef.DisplayName;

                            if (!int.TryParse(fieldDef.DisplayData, out int dictId))
                                continue;

                            var dictItemsList = _dictService.GetById(dictId).DictionaryItems.ToList();

                            object[] dictItems = _dictService.GetById(dictId).DictionaryItems.ToArray();
                            comboBox.Items.AddRange(dictItems);
                            comboBox.DisplayMember = "Name";
                            comboBox.ValueMember = "Id";

                            _getValueFuncs.Add(fieldDef.Code, () =>
                            {
                                var selectedItem = comboBox.SelectedItem as DictionaryItem;

                                if (selectedItem is null)
                                    return "";

                                return selectedItem.Id.ToString();
                            });

                            if (isRequired)
                                _validateDataFuncs.Add(fieldDef.Code, () =>
                                {
                                    var selectedItem = comboBox.SelectedItem as DictionaryItem;
                                    if (selectedItem is null)
                                    {
                                        this.errorProvider1.SetError(comboBox, "To pole jest wymagane");
                                        return false;
                                    }

                                    return true;
                                });

                            var existingValue = _data.UserWorkflowFieldValues.FirstOrDefault(x => x.FieldCode == stageField.FieldCode);
                            if (existingValue is not null)
                            {

                                if (int.TryParse(existingValue.FieldValue, out int selectedItemId))
                                {
                                    var foundItem = dictItemsList.FirstOrDefault(x => x.Id == selectedItemId);
                                    comboBox.SelectedItem = foundItem;
                                }

                            }

                            controlToAdd = comboBox;
                        }
                        break;
                    case WorkflowFieldType.User:
                        {
                            var comboBox = new System.Windows.Forms.ComboBox();
                            comboBox.Name = fieldDef.Code;
                            //comboBox.Text = fieldDef.DisplayName;

                            var usersList = _userService.GetAll().ToList();

                            comboBox.Items.AddRange(usersList.ToArray());
                            comboBox.DisplayMember = "Login";
                            comboBox.ValueMember = "Id";

                            _getValueFuncs.Add(fieldDef.Code, () =>
                            {
                                var selectedItem = comboBox.SelectedItem as User;

                                if (selectedItem is null)
                                    return "";

                                return selectedItem.Id.ToString();
                            });

                            if (isRequired)
                                _validateDataFuncs.Add(fieldDef.Code, () =>
                                {
                                    var selectedItem = comboBox.SelectedItem as User;
                                    if (selectedItem is null)
                                    {
                                        this.errorProvider1.SetError(comboBox, "To pole jest wymagane");
                                        return false;
                                    }

                                    return true;
                                });

                            var existingValue = _data.UserWorkflowFieldValues.FirstOrDefault(x => x.FieldCode == stageField.FieldCode);
                            if (existingValue is not null)
                            {

                                if (int.TryParse(existingValue.FieldValue, out int selectedItemId))
                                {
                                    var foundItem = usersList.FirstOrDefault(x => x.Id == selectedItemId);
                                    comboBox.SelectedItem = foundItem;
                                }

                            }

                            controlToAdd = comboBox;
                        }
                        break;
                    case WorkflowFieldType.Date:
                        {
                            var dateTimePicker = new DateTimePicker();

                            if (isRequired)
                                _validateDataFuncs.Add(fieldDef.Code, () =>
                                {
                                    var selectedItem = dateTimePicker.Value;
                                    if (selectedItem <= DateTime.MinValue)
                                    {
                                        this.errorProvider1.SetError(dateTimePicker, "To pole jest wymagane");
                                        return false;
                                    }

                                    return true;
                                });

                            _getValueFuncs.Add(fieldDef.Code, () =>
                            {
                                return dateTimePicker.Value.ToString().ToLower().Trim();
                            });

                            var existingValue = _data.UserWorkflowFieldValues.FirstOrDefault(x => x.FieldCode == stageField.FieldCode);
                            if (existingValue is not null)
                                dateTimePicker.Value = DateTime.Parse(existingValue.FieldValue.ToString());

                            controlToAdd = dateTimePicker;
                        }
                        break;
                    default:
                        continue;
                        break;
                }

                controlToAdd.Visible = isVisible;
                controlToAdd.Enabled = isEditable;
                controlToAdd.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                controlToAdd.AutoSize = true;
                controlToAdd.Width = 300;

                if (!skipLabel && isVisible)
                    flowLayoutPanel.Controls.Add(label);

                flowLayoutPanel.Controls.Add(controlToAdd);

            }
        }

        public static bool Open(int id)
        {
            var form = new UserWorkflowForm(id);

            return form.ShowDialog() == DialogResult.OK;
        }

        public static bool OpenInReadOnlyMode(int id)
        {
            var form = new UserWorkflowForm(id);
            form._isReadOnly = true;
            form.button1.Enabled = false;
            form.button2.Enabled = false;
            return form.ShowDialog() == DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckIfUserIsAssignedToStage();

            this.errorProvider1.Clear();
            var isValid = true;

            isValid = isValid && _validateDataFuncs.Select(x => x.Value).All(x => x());

            if (isValid)
            {
                SetFieldValues();
                var confirm = AppManager.ShowYesNoDialog("Potwierdzenie operacji", "Czy napewno chcesz przekazać przepływ do następnego etapu?");

                if (confirm)
                {
                    ForwardToNextStage();

                    AppManager.ShowDataSavedMessage();
                    CloseWithDialogResult(DialogResult.OK);
                }

            }
        }

        private void CheckIfUserIsAssignedToStage()
        {
            if (_data.CurrentStageAssignedToUserId != AppManager.Instance.CurrentUser.Id)
            {
                var result = AppManager.ShowYesNoDialog("Potwierdzenie operacji", "Przed obsłużeniem etapu musi on zostać przypisany do użytkownika? Czy chcesz przypisać ten etap do siebie?");

                if (result)
                    _service.AssignToCurrentUser(_data.Id, _data.CurrentStageId);
                else
                    return;

            }
        }

        private void ForwardToNextStage()
        {
            var lastStage = _data.Workflow.WorkflowStage.OrderBy(x => x.StageIndex).Last();
            var isLastStage = _data.CurrentStage.Id == lastStage.Id;

            if (isLastStage)
            {
                var result = AppManager.ShowYesNoDialog("Potwierdzenie operacji", "Przepływ jest na ostatnim etapie. Czy napewno chcesz go zakończyć?");

                if (result)
                {
                    _service.CompleteWorkflow(_data);
                    CloseWithDialogResult(DialogResult.OK);
                    return;
                }

                return;
            }
            else
            {
                _service.ForwardToNextStage(_data);
            }
        }

        private void SetFieldValues()
        {
            foreach (var stageField in _data.CurrentStage.StageFields)
            {
                var fieldDef = _data.Workflow.WorkflowFields.FirstOrDefault(x => x.Code == stageField.FieldCode);

                if (fieldDef is null)
                    continue;

                var fieldValueFunc = _getValueFuncs.FirstOrDefault(x => x.Key == fieldDef.Code);

                if (fieldValueFunc.Value is null)
                    continue;

                var fieldValue = _data.UserWorkflowFieldValues.FirstOrDefault(x => x.FieldCode == fieldDef.Code);

                if (fieldValue is null)
                {
                    var val = fieldValueFunc.Value();
                    var value = new UserWorkflowFieldValue()
                    {
                        UserWorkflowId = _data.Id,
                        FieldCode = fieldDef.Code,
                        FieldValue = val
                    };

                    _data.UserWorkflowFieldValues.Add(value);
                }
                else
                {
                    var val = fieldValueFunc.Value();

                    fieldValue.FieldValue = val;
                }
            }
        }



        private void GoBackToPreviousStage()
        {
            var firstStage = _data.Workflow.WorkflowStage.OrderBy(x => x.StageIndex).First();
            var isFirstStage = _data.CurrentStage.Id == firstStage.Id;

            if (isFirstStage)
            {
                AppManager.ShowErrorMessage("Nie można cofnąć do poprzedniego etapu, ponieważ jest to pierwszy etap przepływu");
                return;
            }

            var reasonForm = new ReasonForm();
            reasonForm.ShowDialog();
            _service.GoBackToPreviousStage(_data, reasonForm.Reason);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CheckIfUserIsAssignedToStage();

            this.errorProvider1.Clear();
            var isValid = true;

            isValid = isValid && _validateDataFuncs.Select(x => x.Value).All(x => x());

            if (isValid)
            {
                SetFieldValues();

                var confirm = AppManager.ShowYesNoDialog("Potwierdzenie operacji", "Czy napewno chcesz cofnąć przepływ do poprzedniego etapu?");

                if (confirm)
                {
                    GoBackToPreviousStage();

                    AppManager.ShowDataSavedMessage();
                    CloseWithDialogResult(DialogResult.OK);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckIfUserIsAssignedToStage();

            this.errorProvider1.Clear();
            var isValid = true;

            isValid = isValid && _validateDataFuncs.Select(x => x.Value).All(x => x());

            if (isValid)
            {
                SetFieldValues();

                var confirm = AppManager.ShowYesNoDialog("Potwierdzenie operacji", "Czy napewno chcesz cofnąć przepływ do poprzedniego etapu?");

                if (confirm)
                {
                    GoBackToPreviousStage();

                    AppManager.ShowDataSavedMessage();
                    CloseWithDialogResult(DialogResult.OK);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.appGridView2.SelectedRows.Count > 0)
            {
                var items = new List<AttachmentDto>();
                foreach (var row in this.appGridView2.SelectedRows)
                {
                    AttachmentDto item = (row as DataGridViewRow).DataBoundItem as AttachmentDto;
                    items.Add(item);
                }

                var filesIds = items.Select(x => x.Id)
                    .ToList();

                DownloadFilesFromApi(filesIds);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UploadFile();
        }
    }
}
