using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace common.controls
{
    public class baseTextBox : TextBox
    {
        public delegate void onFind(object sender);
        public event onFind myOnFind = null;

        public bool isBeepOnError = false;
        private bool _isRequired = true;
        public bool isRequired
        {
            get { return _isRequired; }
            set { _isRequired = value; }
        }
        private bool _isToUpperCase = false;
        public bool isToUpperCase
        {
            get { return _isToUpperCase; }
            set { _isToUpperCase = value; }
        }

        public string lastValue = "";
        public string[] validItemList = null;
        public baseTextBox() { }
        public virtual void EndChanged()
        {
            this.lastValue = this.Text;
        }
        public override string Text
        {
            get
            {
                return base.Text.Trim();
            }
            set
            {
                //Prevent that un-neccessary changes to bound field that can make change-detection funtion work improperly
                string tmpValue = (value == null ? "" : value.Trim());
                if (this.Text.Trim() == tmpValue) return;
                base.Text = tmpValue;
            }
        }
        public virtual bool isChangedByEdit()
        {
            return this.Text != this.lastValue;
        }
        private bool FindHandler()
        {
            if (myOnFind == null) return false;
            myOnFind(this);
            return true;
        }
        protected virtual bool DataValid() { return true; }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (common.sysLibs.HaveFindMarker(e.KeyChar.ToString()))
            {
                if (FindHandler())
                {
                    return;
                }
            }

            base.OnKeyPress(e);
            if (!this.isToUpperCase || char.IsUpper(e.KeyChar) || char.IsControl(e.KeyChar)) return;
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        //protected override void OnTextChanged(EventArgs e)
        //{
        //    base.OnTextChanged(e);
        //    if (common.system.HaveFindMarker(this.Text) || (this.isRequired && this.Text.Trim() == ""))
        //    {
        //        FindHandler();
        //    }
        //}
        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            if (common.sysLibs.HaveFindMarker(this.Text) || (this.isRequired && this.Text.Trim() == ""))
            {
                FindHandler();
            }
            this.lastValue = this.Text;
        }
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            FindHandler();
        }
        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            base.OnValidating(e);
            DataValid();
            if (this.Text.Trim() != "" && !sysLibs.InList(this.validItemList, this.Text))
            {
                //sysLibs.ShowErrorMessage(String.Format(language.GetString("dataMustBeInList"), system.ToString(validItemList)));
                e.Cancel = true;
            }
        }
    }
    public class baseMaskedTextBox : MaskedTextBox
    {
        public delegate void onFind(object sender);
        public event onFind myOnFind = null;
        private void DoFind()
        {
            if (myOnFind != null) myOnFind(this);
        }

        public int maxlen = int.MinValue;
        public bool isRequired = false;
        public bool isToUpperCase = false;
        protected string lastValue = "";
        public string[] validItemList = null;
        public baseMaskedTextBox() { }
        public virtual void EndChanged()
        {
            this.lastValue = this.Text;
        }
        public override string Text
        {
            get
            {
                return base.Text.Trim();
            }
            set
            {
                //Prevent that un-neccessary changes to bound field that can make change-detection funtion work improperly
                string tmpValue = (value == null ? "" : value.Trim());
                if (this.Text.Trim() == tmpValue) return;
                base.Text = tmpValue;
            }
        }
        public virtual bool isChangedByEdit()
        {
            return this.Text != this.lastValue;
        }
        protected virtual bool DataValid() { return true; }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == Settings.sysFindMarker)
            {
                DoFind();
                e.Handled = true;
                return;
            }
            base.OnKeyPress(e);
            if (!this.isToUpperCase || char.IsUpper(e.KeyChar) || char.IsControl(e.KeyChar)) return;
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if ((this.maxlen > 0) && (this.Text.Length > this.maxlen))
            {
                //system.ShowErrorMessage(String.Format(language.GetString("dataTooLong"), this.maxlen));
                //this.Text = this.Text.Substring(0, this.maxlen);
                this.Text = "";
            }
        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            this.lastValue = this.Text;
        }
        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            base.OnValidating(e);
            e.Cancel = !DataValid();
            if (this.Text.Trim() != "" && !sysLibs.InList(this.validItemList, this.Text))
            {
                //system.ShowErrorMessage(String.Format(language.GetString("dataMustBeInList"), system.ToString(validItemList)));
                e.Cancel = true;
            }
        }
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            DoFind();
        }
    }
    
    public class baseComboBox : System.Windows.Forms.ComboBox
    {
        private bool fProcessing = false;
        public string lastValue = "";
        public baseComboBox()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            try
            {
                if (this.fProcessing) return;
                this.fProcessing = true;
                base.OnSelectedIndexChanged(e);
                if (this.SelectedValue == null) this.lastValue = null;
                else this.lastValue = this.SelectedValue.ToString();
            }
            finally
            {
                this.fProcessing = false;
            }
        }
        public override string ToString()
        {
            return "ComboBox";
        }
        public virtual void LoadData() { }
        public virtual void SetFilter(string filter)
        {
            if (this.DataSource == null) return;
            DataTable tbl = (DataTable)this.DataSource;
            tbl.DefaultView.RowFilter = filter;
            if (tbl.DefaultView.Count > 0 && this.SelectedIndex < 0) this.SelectedIndex = 0;
        }
        public virtual string myValue
        {
            get
            {
                if (this.SelectedValue == null) return "";
                return this.SelectedValue.ToString();
            }

            set
            {
                if (this.Items.Count <= 0) return;
                if (this.SelectedValue == null) this.SelectedIndex = 0;
                if (this.ValueMember.Trim() != "") this.SelectedValue = value;
            }
        }
        public DataRowView GetCurrentRow()
        {
            if (this.SelectedIndex < 0) return null;
            return (DataRowView)this.Items[this.SelectedIndex];
        }

    }
    public class txtDateTime : baseMaskedTextBox
    {
        public txtDateTime()
        {
            this.Mask = "00/00/0000";
            this.InsertKeyMode = InsertKeyMode.Overwrite;
            this.BeepOnError = true;
        }
        public DateTime myDateTime
        {
            get
            {
                DateTime dt = DateTime.Today;
                if (!DateTime.TryParse(this.Text, out dt)) return DateTime.MinValue;
                return dt;
            }
            set
            {
                this.Text = value.ToShortDateString();
            }
        }
        protected override bool DataValid()
        {
            if (this.myDateTime == DateTime.MinValue) return !this.isRequired;
            return true;
        }
    }
    public class numberTextBox : baseMaskedTextBox
    {
        // The default currency symbol is the dollar sign.
        private string m_format = "###,###,###,###,###";
        public numberTextBox()
        {
            // Include the character prompt and the literals in the format of the text.
            base.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.Mask = "";
        }

        public override bool isChangedByEdit()
        {
            decimal amt = 0; decimal.TryParse(this.Text, out amt);
            return amt.ToString() != this.lastValue;
        }
        public override void EndChanged()
        {
            decimal amt = 0; decimal.TryParse(this.Text, out amt);
            this.lastValue = amt.ToString();
        }

        /// <summary>
        /// Attempts the convert the text entered in the CurrencyMaskedTextBox to a
        /// decimal value.
        /// </summary>
        /// <param name="data">The decimal value of the text.</param>
        /// <returns>True if the conversion was successful; otherwise, false.</returns>
        public bool TryGetValue(out decimal data)
        {
            string tmp = RemovePromptAndLiterals(this.Text);
            return decimal.TryParse(tmp, NumberStyles.Any, this.Culture, out data);
        }

        /// <summary>
        /// Gets or sets a value containing the amount entered in the CurrencyMaskedTextBox
        /// </summary>
        public decimal Value
        {
            get
            {
                decimal result = 0;

                TryGetValue(out result);

                return result;
            }
            set
            {
                SetValue(value);
            }
        }

        /// <summary>
        /// Removes the prompt and literal characters from the specified data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>The numeric value of the specified data as a string.</returns>
        private string RemovePromptAndLiterals(string data)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(data);

            // Replace spaces by empty
            sb.Replace(" ", string.Empty);
            // Replace the Prompt Character by empty
            sb.Replace(this.PromptChar.ToString(), string.Empty);
            // Replace the currency symbol by empty
            sb.Replace(this.CurrencySymbol.ToString(), string.Empty);
            // Replace the thousand separator by empty
            sb.Replace(this.Culture.NumberFormat.NumberGroupSeparator, string.Empty);

            return sb.ToString();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.Text = this.Value.ToString();
            this.SelectAll();
            base.OnEnter(e);
        }
        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            decimal value = 0;
            if (TryGetValue(out value)) SetValue(value);
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                decimal num = 0;
                // Attempt to parse the specified text
                if (!decimal.TryParse(RemovePromptAndLiterals(value), NumberStyles.Any, this.Culture, out num)) num = 0;
                SetValue(num);
            }
        }

        private void SetValue(decimal v)
        {
            //this.Mask = "";
            base.Text = DecimalToString(v);
        }

        private string DecimalToString(decimal data)
        {
            string tmp = data.ToString(this.myFormat, this.Culture);
            return ReplaceLeadingZeros(tmp);
        }

        /// <summary>
        /// Replaces the leading zeros in the specified data by the 
        /// prompt character for the CurrencyMaskedTextBox.
        /// </summary>
        /// <param name="data">The formatted string representation of the value
        /// in the TextBox.</param>
        /// <returns>A string formatted for display in the TextBox.</returns>
        protected string ReplaceLeadingZeros(string data)
        {
            return data;

            char thousandSeparator = this.Culture.NumberFormat.NumberGroupSeparator.ToCharArray()[0];
            char[] chars = data.ToCharArray();
            char[] NewData = new char[chars.Length];

            // Copy all the characters from the original data array into the new one
            chars.CopyTo(NewData, 0);

            // Loop through the elements of the data array
            // Only replace 0 with the prompt character in front of the decimal point
            for (int i = 0; i < chars.Length; i++)
            {
                // If the element is not a currency symbol, a blank
                // or a thousand separator
                if (chars[i] != this.CurrencySymbol &&
                    chars[i] != ' ' &&
                    chars[i].ToString() != this.Culture.NumberFormat.NumberDecimalSeparator)
                {
                    if (chars[i] == '0')
                        // This is a leading zero, replace it with the prompt character
                        NewData[i] = this.PromptChar;
                    else if (chars[i] != ',')
                        // This is the first non-zero and non-literal
                        // However, it's also not a thousand separator (always , in the mask used
                        // to format the data argument)
                        break;
                }
            }

            // In some cultures, the currency symbol may be at the end of the string
            // In that case, it should be the last character, but there may be a space between
            // the last digit and the currency symbol,
            // e.g. "1000.0000 €"
            // Include a guard clause in case the data argument is empty
            if (chars.Length > 0 &&
                chars[chars.Length - 1] == this.CurrencySymbol)
            {
                NewData[chars.Length - 1] = this.PromptChar;

                // Check for the space in the second to last position
                if (chars.Length > 1 && chars[chars.Length - 2] == ' ')
                {
                    NewData[chars.Length - 2] = this.PromptChar;
                }
            }

            return new string(NewData);
        }

        /// <summary>
        /// Gets or sets a value containing the currency literal used for this
        /// CurrencyMaskedTextBox.
        /// </summary>
        public char CurrencySymbol
        {
            get
            {
                return this.Culture.NumberFormat.CurrencySymbol.ToCharArray()[0];
            }
        }
        public string myFormat
        {
            get { return m_format; }
            set
            {
                m_format = value;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }

    public class cbNumberList : baseComboBox
    {
        public cbNumberList()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void MakeList(int start,int end)
        {
            this.Items.Clear();
            int year = DateTime.Today.Year;
            for (int idx = start; idx <= end; idx++) this.Items.Add(idx.ToString());
            this.MaxDropDownItems = end - start + 1;
        }
        private int startNumber
        {
            get
            {
                if (this.Items.Count < 0) return int.MinValue;
                int number = 0;
                if (!int.TryParse(this.Items[0].ToString(), out number)) return int.MinValue;
                return number;
            }
        }
        protected int myNumber
        {
            get
            {
                if (this.SelectedIndex < 0) return int.MinValue;
                return this.startNumber + this.SelectedIndex;
            }

            set
            {
                if (this.Items.Count <= 0) return;
                if (value - this.startNumber>=0 && value - this.startNumber<this.Items.Count)
                    this.SelectedIndex = value - this.startNumber;
            }
        }
        public override string myValue
        {
            get
            {
                return this.myNumber.ToString();
            }
            set
            {
                int number = 0;
                if (int.TryParse(value, out number)) this.myNumber = number;
            }
        }
    }
    public class cbYear : cbNumberList
    {
        public cbYear()
        {
            if (DesignMode) return;
            int year = DateTime.Today.Year;
            MakeList(year - 5, year + 5);
            this.myYear = year;

        }
        public int myYear
        {
            get {return this.myNumber;}
            set {this.myNumber = value;}
        }
    }
    public class cbMonth : cbNumberList
    {
        public cbMonth()
        {
            if (DesignMode) return;
            MakeList(1,12);
            this.myMonth = DateTime.Today.Month;
        }
        public int myMonth
        {
            get {return this.myNumber;}

            set {this.myNumber = value;}
        }
    }
}
