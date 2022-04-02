using Kingdee.BOS.WebApi.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace webapi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            K3CloudApiClient client = new K3CloudApiClient("http://183.129.248.194:8888/k3cloud/");
            var loginResult = client.ValidateLogin("60b094557e374a", "Administrator", "sql@2021!", 2052);


            var resultType = JObject.Parse(loginResult)["LoginResultType"].Value<int>();
            //登录结果类型等于1，代表登录成功


            if (resultType == 1)
            {

                string xjson = Tjson();

                string _kjson = client.View("PRD_MO", xjson);


                if (_kjson.IndexOf("您要读取的数据在系统中不存在,可能已经被删除") >= 0)
                {
                    MessageBox.Show("您要读取的数据在系统中不存在,可能已经被删除");
                }
                else
                {

                    _kjson = _kjson.Replace("{\"Result\":", "{\"ResultX\":");

                    InserMo _mo = new InserMo();

                    xjson = _mo.InserMoX(_kjson);

                    MySql _sql = new MySql();

                    int f = _sql.getmysqlcom(xjson);

                    MessageBox.Show("成功新增" + f.ToString() + "条数据");

                }
            }
        }
        public string Tjson()
        {

            MySql _sql = new MySql();


            long _fid = Convert.ToInt64(_sql.GetMaxFid("t_prd_mo"));

            if (_fid == 0)
            {
                _fid = 100012;
            }

            string _json = "{\"CreateOrgId\": 0,    \"Number\": \"\",\"Id\": \"" + (_fid + 1).ToString() + "\"}";


            return _json;
        }


    }




}
