namespace SrtMacro_v02.Models.SRT
{
    /// <summary>
    /// SRT MODEL CLASS
    /// </summary>
    internal class SrtModels
    {
        private string id;
        private string pw;
        private string date;
        private string startaddress;
        private string stopaddress;
        private string starttime;
        private string endtime;
        private string adult;
        private string child;
        private int delay;

        /// <summary>
        /// SRT ID
        /// </summary>
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }

        }

        /// <summary>
        /// SRT PASSWORD
        /// </summary>
        public string PW
        {
            get
            {
                return pw;
            }
            set
            {
                pw = value;
            }
        }

        /// <summary>
        /// SRT DATE
        /// </summary>
        public string DATE
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        /// <summary>
        /// SRT STARTADDRESS
        /// </summary>
        public string STARTADDRESS
        {
            get
            {
                return startaddress;
            }
            set
            {
                startaddress = value;
            }
        }

        /// <summary>
        /// SRT STOPADDRESS
        /// </summary>
        public string STOPADDRESS
        {
            get
            {
                return stopaddress;
            }
            set
            {
                stopaddress = value;
            }
        }

        /// <summary>
        /// SRT STARTTIME
        /// </summary>
        public string STARTTIME
        {
            get
            {
                return starttime;
            }
            set
            {
                starttime = value;
            }
        }

        /// <summary>
        /// SRT ENDTIME
        /// </summary>
        public string ENDTIME
        {
            get
            {
                return endtime;
            }
            set
            {
                endtime = value;
            }
        }

        /// <summary>
        /// SRT ADULT
        /// </summary>
        public string ADULT
        {
            get
            {
                return adult;
            }
            set
            {
                adult = value;
            }
        }

        /// <summary>
        /// SRT CHILD
        /// </summary>
        public string CHILD
        {
            get
            {
                return child;
            }
            set
            {
                child = value;
            }
        }

        /// <summary>
        /// Refresh Delay
        /// </summary>
        public int DELAY
        {
            get
            {
                return delay;
            }
            set
            {
                delay = value;
            }
        }
    }
}
