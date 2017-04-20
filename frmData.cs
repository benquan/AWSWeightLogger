using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GenericHid
{


    public partial class frmData : Form
    {


        string provider;
        string dataFile;
        string connString;
        
        OleDbConnection myConnection = new OleDbConnection();
        int userID;
        Random Rand = new Random();


        public frmData()
        {
            InitializeComponent();

            Chart1.Series["Series1"].Name = "Weight";
            Chart1.Series["Series2"].Name = "Fat";
            Chart1.Series["Series3"].Name = "Muscle";
            Chart1.Series["Series4"].Name = "Water";

            Chart1.Series["Weight"].BorderWidth = 3;

            comboBox1.SelectedIndex = 0;

            //drawChart()


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(comboBox1.SelectedIndex);
            drawChart();
        }




        private void drawChart()
        {

            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\BioWeigh.accdb";
            string tblFields = "SELECT * from qryData where userid = " + comboBox1.SelectedIndex + 1 + " order by fecha ";

            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand oCmd = new OleDbCommand(tblFields, conn);
            OleDbDataAdapter oData = new OleDbDataAdapter(tblFields, conn);
            DataSet ds = new DataSet();

            conn.Open();
            oData.Fill(ds, "qryData");
            conn.Close();

            Chart1.DataSource = ds.Tables["qryData"];
            Series Series1 = Chart1.Series["Weight"];
            Series Series2 = Chart1.Series["Fat"];
            Series Series3 = Chart1.Series["Muscle"];
            Series Series4 = Chart1.Series["Water"];


            Series1.XValueMember = "Fecha";
            Series1.YValueMembers = "Weight";


            Series2.XValueMember = "Fecha";
            Series2.YValueMembers = "Fat";
            Series2.YAxisType = AxisType.Secondary;


            Series3.XValueMember = "Fecha";
            Series3.YValueMembers = "Muscle";
            Series3.YAxisType = AxisType.Secondary;


            Series4.XValueMember = "Fecha";
            Series4.YValueMembers = "Water";
            Series4.YAxisType = AxisType.Secondary;

            Chart1.ChartAreas[0].AxisY.Minimum = 100;
        }

    }

}
