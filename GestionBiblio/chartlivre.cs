﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBiblio
{
    public partial class chartlivre : Form
    {
        string parametres = "SERVER=127.0.0.1; DATABASE=gestion_bibliotheque; UID=root; PASSWORD=";
        private MySqlConnection maconnexion;
        

        public chartlivre()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
        }

        private void chartlivre_Load(object sender, EventArgs e)
        {
            maconnexion = new MySqlConnection(parametres);  
            DataSet ds = new DataSet();
            maconnexion.Open();
            string request = "Select count(*) as number_x,titre from livres group by titre";
            MySqlCommand cmd = new MySqlCommand(request, maconnexion);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            chart1.DataSource = ds;
            //set the member of the chart data source used to data bind to the X-values of the series  
            chart1.Series["livres"].XValueMember = "titre";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chart1.Series["livres"].YValueMembers = "number_x";
            chart1.Titles.Add("Nombre des Livres Dispo");
            maconnexion.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
