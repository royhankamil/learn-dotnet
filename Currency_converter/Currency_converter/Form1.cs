using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Currency_converter
{
    public partial class Form1: Form
    {
        CurrencyConverterEntities db = new CurrencyConverterEntities();
        List<Period> periods;
        Currency originC, convertedC;
        int lastIndexCB2 = -1, lastIndexCB3 = -1;
        string lastInput = "";

        public Form1()
        {
            InitializeComponent();

            periods = db.Periods.ToList();

            foreach (Period period in periods)
            {
                comboBox1.Items.Add(period.name);
            }

            comboBox1.SelectedIndex = 0;


            foreach(var data in db.Currencies.ToList())
            {
                comboBox3.Items.Add(data.abbreviation);
                comboBox2.Items.Add(data.abbreviation);
            }

            comboBox3.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;

            errorTxt.Text = "";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == comboBox2.SelectedIndex)
            {
                comboBox2.SelectedIndex = lastIndexCB3;
            }

            originC = db.Currencies.First(c => c.abbreviation == comboBox3.Text);

            OriginLabel.Text = originC.name;

            lastIndexCB3 = comboBox3.SelectedIndex;
            countNumeric();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == comboBox3.SelectedIndex)
            {
                comboBox3.SelectedIndex = lastIndexCB2;
            }

            convertedC = db.Currencies.First(c => c.abbreviation == comboBox2.Text);

            ConvertedLabel.Text = convertedC.name;
            lastIndexCB2 = comboBox2.SelectedIndex;
            countNumeric();
        }

        private void OriginInput_TextChanged(object sender, EventArgs e)
        {
            
            if (OriginInput.Text.Contains("."))
            {
                if (OriginInput.Text.Split('.')[1].Length > 10)
                {
                    OriginInput.Text = lastInput;
                    OriginInput.SelectionStart = OriginInput.TextLength;
                }
            }

            countNumeric();

            lastInput = OriginInput.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lastIndexCB2 = comboBox2.SelectedIndex;

            comboBox2.SelectedIndex = comboBox3.SelectedIndex;
            comboBox3.SelectedIndex = lastIndexCB2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            countNumeric();
        }

        private void countNumeric()
        {
            errorTxt.Text = "";
            if (OriginInput.Text != "")
            {
                decimal inputNum;
                if (decimal.TryParse(OriginInput.Text.Replace(".", ","), out inputNum))
                {
                    decimal originExchange = db.USDExchangeRates.FirstOrDefault(c => c.currency_id == originC.id).rate;
                    decimal convertedExchange = db.USDExchangeRates.FirstOrDefault(c => c.currency_id == convertedC.id).rate;

                    decimal output = convertedExchange / originExchange * inputNum;
                    textBox1.Text = output.ToString("0.000").Replace(",", ".");
                }
                else
                {
                    errorTxt.Text = "Please input with decimal number";
                }
            }
        }
    }
}
