using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrtMacro_v02.Models.KTX
{
    class Values
    {
        /// <summary>
        /// 지역
        /// </summary>
        public static List<string> AddressList = new List<string>()
        {
            "서울",
            "용산",
            "영등포",
            "광명",
            "수원",
            "천안아산",
            "오송",
            "대전",
            "서대전",
            "김천",
            "구미",
            "김천구미",
            "동대구",
            "포항",
            "밀양",
            "구포",
            "부산",
            "신경주",
            "울산(통도사)",
            "마산",
            "창원중앙",
            "경산",
            "논산",
            "익산",
            "정읍",
            "광주송정",
            "목포",
            "전주",
            "순천",
            "여수EXPO",
            "청량리",
            "강릉",
            "행신",
            "정동진"
        };

        /// <summary>
        /// 새로고침 딜레이 타이머
        /// </summary>
        public static Dictionary<string, int> DelayTime = new Dictionary<string, int>()
        {
            {"1초",1000 },
            {"2초",2000 },
            {"3초",3000 },
            {"4초",4000 },
            {"5초",5000 },
            {"6초",6000 },
            {"7초",7000 },
            {"8초",8000 },
            {"9초",9000 },
            {"10초",10000 }
        };

        /// <summary>
        /// 시간
        /// </summary>
        public static Dictionary<string,string> StartList = new Dictionary<string,string>()
        {
            { "0 (오전00)","00:00"},
            { "1 (오전01)","01:00"},
            { "2 (오전02)","02:00"},
            { "3 (오전03)","03:00"},
            { "4 (오전04)","04:00"},
            { "5 (오전05)","05:00"},
            { "6 (오전06)","06:00"},
            { "7 (오전07)","07:00"},
            { "8 (오전08)","08:00"},
            { "9 (오전09)","09:00"},
            { "10 (오전10)","10:00"},
            { "11 (오전11)","11:00"},
            { "12 (오후00)","12:00"},
            { "13 (오후01)","13:00"},
            { "14 (오후02)","14:00"},
            { "15 (오후03)","15:00"},
            { "16 (오후04)","16:00"},
            { "17 (오후05)","17:00"},
            { "18 (오후06)","18:00"},
            { "19 (오후07)","19:00"},
            { "20 (오후08)","20:00"},
            { "21 (오후09)","21:00"},
            { "22 (오후10)","22:00"},
            { "23 (오후11)","23:00"},
        };

        /// <summary>
        /// 어른 리스트
        /// </summary>
        public static List<string> AdultList = new List<string>()
        {
            "어른 0명",
            "어른 1명",
            "어른 2명",
            "어른 3명",
            "어른 4명",
            "어른 5명",
            "어른 6명",
            "어른 7명",
            "어른 8명",
            "어른 9명"
        };

        /// <summary>
        /// 어린이 리스트
        /// </summary>
        public static List<string> ChildrenList = new List<string>()
        {
            "만 6세~12세",
            "어린이 1명",
            "어린이 2명",
            "어린이 3명",
            "어린이 4명",
            "어린이 5명",
            "어린이 6명",
            "어린이 7명",
            "어린이 8명",
            "어린이 9명"
        };

        /// <summary>
        /// 유아 리스트
        /// </summary>
        public static List<string> ChildList = new List<string>()
        {
            "만 6세 미만",
            "유아 1명",
            "유아 2명",
            "유아 3명",
            "유아 4명",
            "유아 5명",
            "유아 6명",
            "유아 7명",
            "유아 8명",
            "유아 9명"
        };

        /// <summary>
        /// 노인 리스트
        /// </summary>
        public static List<string> OldList = new List<string>()
        {
            "만 65세이상",
            "경로 1명",
            "경로 2명",
            "경로 3명",
            "경로 4명",
            "경로 5명",
            "경로 6명",
            "경로 7명",
            "경로 8명",
            "경로 9명"
        };

        /// <summary>
        /// BaseDirect 경로
        /// </summary>
        public static string BaseDirectPath = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 설정파일 경로
        /// </summary>
        public static string SetPath = string.Format(@"{0}\\KTXMacro.json", BaseDirectPath);

    }
}
