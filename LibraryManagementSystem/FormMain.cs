using BLL;
using LibraryManager;
using Model;

namespace LibraryManagementSystem
{
    //��������
    public partial class FormMain : Form
    {
        //��ȡ����������Ŀؼ�
        private Control? GetControl(Control.ControlCollection controlCollection)
        {
            foreach (Control control in controlCollection)
            {
                //��ȡ�ؼ���Ŀؼ�
                if (control.Controls.Count != 0)
                    return GetControl(control.Controls);
                else
                    return control;
            }
            return null;
        }
        public FormMain()
        {
            InitializeComponent();
        }

        //�����ڼ��س���
        private void FormMain_Load(object sender, EventArgs e)
        {
            //������������һ�����ڿؼ���ʹ���������ܹ��л����С����
            ControlWin_ListUserInfo formListUserInfo = new ControlWin_ListUserInfo();
            panWin.Controls.Add(formListUserInfo);
        }

        //ɾ����ť�����¼�
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //��ȡ����б������
            Control? control = GetControl(panWin.Controls);
            ListView lstView = new ListView();
            if (control != null)
            {
                lstView = (ListView)(control);
            }
            else
            {
                this.Close();
            }

            Model.Mod_UserInfo mod_userinfo = new Model.Mod_UserInfo();
            BLL_UserInfo bll_userinfo = new BLL_UserInfo();

            //�ж��Ƿ�ѡ����
            if (lstView.SelectedItems.Count == 0)
            {
                MessageBox.Show("There is no selected row!", "Wrong");
            }
            else
            {
                //��ȡѡ���е���Ϣ
                mod_userinfo.UserID = lstView.SelectedItems[0].SubItems[0].Text;
                mod_userinfo.UserName = lstView.SelectedItems[0].SubItems[1].Text;
                mod_userinfo.UserPWD = lstView.SelectedItems[0].SubItems[2].Text;
                mod_userinfo.UserType = lstView.SelectedItems[0].SubItems[3].Text;
                
                bll_userinfo.UserDelete(mod_userinfo);
            }
        }

        //���밴ť�����¼�
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //�������û�����
            FormIncrease forminsert = new FormIncrease();
            forminsert.Show();
        }

        //�޸İ�ť�����¼�
        private void btnModify_Click(object sender, EventArgs e)
        {
            Control? control = GetControl(panWin.Controls);
            ListView lstView = new ListView();
            if (control != null)
            {
                lstView = (ListView)(control);
            }
            else
            {
                this.Close();
            }

            //�ж��Ƿ�ѡ����
            if (lstView.SelectedItems.Count == 0)
            {
                MessageBox.Show("There is no selected row!", "Wrong");
            }
            else
            {
                //������´���
                FormUpdat form = new FormUpdat();

                //���û���Ϣ���ݵ�������Ϣ����
                form.UserID = lstView.SelectedItems[0].SubItems[0].Text;
                form.Show();
            }
        }

        //�����ͼ��ť�����¼�
        private void btnView_Click(object sender, EventArgs e)
        {
            Control? control = GetControl(panWin.Controls);
            ListView lstView = new ListView();
            if (control != null)
            {
                lstView = (ListView)(control);
            }
            else
            {
                this.Close();
            }

            BLL.BLL_UserInfo bll_userinfo = new BLL.BLL_UserInfo();
            List<Model.Mod_UserInfo> userInfos = bll_userinfo.UserList();
            lstView.Items.Clear();

            //����ѯ������Ϣ��ʾ���б�Ķ�Ӧ��
            foreach (Model.Mod_UserInfo userInfo in userInfos)
            {
                string[] item = new string[lstView.Columns.Count];
                item[0] = userInfo.UserID;
                item[1] = userInfo.UserName;
                item[2] = userInfo.UserPWD;
                item[3] = userInfo.UserType;
                lstView.Items.Add(new ListViewItem(item));
            }
        }       
    }
}