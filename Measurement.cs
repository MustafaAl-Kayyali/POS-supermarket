using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket
{
    public partial class Measurement : Form
    {
        private string selectedMeasurement;

        public Measurement()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Check if an item is selected in the ComboBox
            if (ComboBoxSelect.SelectedItem != null)
            {
                // Store the selected item from the ComboBox
                selectedMeasurement = ComboBoxSelect.SelectedItem.ToString();

                // Display the selected item in the ListBox
                listBoxSelected.Items.Clear();
                listBoxSelected.Items.Add(selectedMeasurement);

                // Close the form after selection
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Display a message if no item is selected in the ComboBox
                MessageBox.Show("Please select an item from the ComboBox before saving.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Method to retrieve the selected item as a string
        public string GetSelectedMeasurement()
        {
            return selectedMeasurement;
        }

        private void Measurement_Load(object sender, EventArgs e)
        {
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Close the form without making a selection
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
