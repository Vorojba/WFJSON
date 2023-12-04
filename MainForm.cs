using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using WFJSON.DBCon;


namespace WFJSON
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public static List<int> JuriList;

        private void MainForm_Load(object sender, EventArgs e)
        {
            activityBindingSource.DataSource = DBConst.model.Activity.ToList();
        }

        private void buttonShowJuri_Click(object sender, EventArgs e)
        {
            JuriList = new List<int>();
            JuriList = JsonSerializer.Deserialize<List<int>>
                (activityDataGridView.CurrentRow.Cells[6].Value.ToString());
            FormShowJuri formShowJuri = new FormShowJuri();
            formShowJuri.ShowDialog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddActivity activity = new FormAddActivity();
            activity.ShowDialog();
            activityBindingSource.DataSource = DBConst.model.Activity.ToList();
        }
    }
}
