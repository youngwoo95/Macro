using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SrtMacro_v02.Models.KTX
{
    /// <summary>
    /// KTX MODEL CLASS
    /// </summary>
    internal class KtxModels
    {
        private string id; // KTX 아이디
        private string pw; // KTX 비밀번호
        private DateTime date; // 예매일
        private string startaddress; // 출발지
        private string stopaddress; // 도착지
        private string starttime; // 출발시간
        private string endtime; // 도착시간
        private string adult; // 어른
        private string children; // 어린이
        private string child; // 유아
        private string old; // 노인
        private int delay; // 새로고침 주기

        /// <summary>
        /// KTX 아이디
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
        /// KTX 비밀번호
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
        /// 예매일
        /// </summary>
        public DateTime DATE
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
        /// 출발지
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
        /// 도착지
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
        /// 출발시간
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
        /// 도착시간
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
        /// 어른
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
        /// 어린이
        /// </summary>
        public string CHILDREN
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
            }
        }

        /// <summary>
        /// 유아
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
        /// 노인
        /// </summary>
        public string OLD
        {
            get
            {
                return old;
            }
            set
            {
                old = value;
            }
        }

        /// <summary>
        /// 새로고침 주기
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
