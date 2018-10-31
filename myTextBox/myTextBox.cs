using System;


namespace myc
{
    public class myTextBox : System.Windows.Forms.TextBox
    {

        private bool bolChengeColor = true;

        private bool bolIsNumeric;

        private bool bolInsertSeparator;

        protected override void OnEnter(EventArgs e)
        {
            if ((bolChengeColor && !this.ReadOnly))
            {
                this.BackColor = System.Drawing.Color.LightYellow;
            }

            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if ((bolChengeColor && !this.ReadOnly))
            {
                this.BackColor = System.Drawing.Color.White;
            }

            base.OnLeave(e);
        }

        [System.ComponentModel.DefaultValue(true)]
        public bool ChangeColor
        {
            get
            {
                return bolChengeColor;
            }
            set
            {
                bolChengeColor = value;
            }
        }

        [System.ComponentModel.DefaultValue(false)]
        public bool InsertSeparator
        {
            get
            {
                return bolInsertSeparator;
            }
            set
            {
                bolInsertSeparator = value;
            }
        }

        [System.ComponentModel.DefaultValue(false)]
        public bool IsNumeric
        {
            get
            {
                return bolIsNumeric;
            }
            set
            {
                bolIsNumeric = value;
            }
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (bolIsNumeric)
            {
                if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }

            base.OnKeyPress(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (bolInsertSeparator)
            {
                try
                {
                    if ((base.Text != "0"))
                    {
                        base.Text = Convert.ToInt64(base.Text.Replace(",", "")).ToString("###,###");
                        SelectionStart = base.Text.Length;
                    }

                }
                catch 
                {
                    base.Text = base.Text.Replace(",", "");
                }

            }

            base.OnTextChanged(e);
        }



    public override string Text
        {
            get
            {
                if ((bolIsNumeric
                            && (base.Text == "")))
                {
                    return "0";
                }

                if (bolInsertSeparator)
                {
                    return base.Text.Replace(",", "");
                }

                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
    }
}
