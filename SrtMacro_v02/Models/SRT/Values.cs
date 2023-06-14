using System;
using System.Collections.Generic;

namespace SrtMacro_v02.Models.SRT
{
    class Values
    {
        /// <summary>
        /// 지역이름 리스트
        /// </summary>
        public static List<string> AddressList = new List<string>()
        {
            "수서",
            "동탄",
            "평택지제",
            "천안아산",
            "오송",
            "대전",
            "김천(구미)",
            "서대구",
            "동대구",
            "신경주",
            "울산(통도사)",
            "부산",
            "공주",
            "익산",
            "정읍",
            "광주송정",
            "나주",
            "목포",
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
        /// 시간 Dictionary
        /// </summary>
        public static Dictionary<string, string> StartList = new Dictionary<string, string>()
        {
            {"00시 이후","00:00"},
            {"02시 이후","02:00"},
            {"04시 이후","04:00"},
            {"06시 이후","06:00"},
            {"08시 이후","08:00"},
            {"10시 이후","10:00"},
            {"12시 이후","12:00"},
            {"14시 이후","14:00"},
            {"16시 이후","16:00"},
            {"18시 이후","18:00"},
            {"20시 이후","20:00"},
            {"22시 이후","22:00"}
        };

        /// <summary>
        /// 시간 Dictionary
        /// </summary>
        public static Dictionary<string, string> EndList = new Dictionary<string, string>()
        {
            {"00시 이전","00:00"},
            {"02시 이전","02:00"},
            {"04시 이전","04:00"},
            {"06시 이전","06:00"},
            {"08시 이전","08:00"},
            {"10시 이전","10:00"},
            {"12시 이전","12:00"},
            {"14시 이전","14:00"},
            {"16시 이전","16:00"},
            {"18시 이전","18:00"},
            {"20시 이전","20:00"},
            {"22시 이전","22:00"}
        };

        /// <summary>
        /// 어른 수 리스트
        /// </summary>
        public static List<string> AdultList = new List<string>()
        {
            "어른(만 13세 이상) 0명",
            "어른(만 13세 이상) 1명",
            "어른(만 13세 이상) 2명",
            "어른(만 13세 이상) 3명",
            "어른(만 13세 이상) 4명",
            "어른(만 13세 이상) 5명",
            "어른(만 13세 이상) 6명",
            "어른(만 13세 이상) 7명",
            "어른(만 13세 이상) 8명",
            "어른(만 13세 이상) 9명"
        };

        /// <summary>
        /// 아이 수 리스트
        /// </summary>
        public static List<string> ChildList = new List<string>()
        {
            "어린이(만 6~12세) 0명",
            "어린이(만 6~12세) 1명",
            "어린이(만 6~12세) 2명",
            "어린이(만 6~12세) 3명",
            "어린이(만 6~12세) 4명",
            "어린이(만 6~12세) 5명",
            "어린이(만 6~12세) 6명",
            "어린이(만 6~12세) 7명",
            "어린이(만 6~12세) 8명",
            "어린이(만 6~12세) 9명"
        };

        /// <summary>
        /// BaseDirect 경로
        /// </summary>
        private static string BaseDirectPath = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 설정파일 경로
        /// </summary>
        public static string SetPath = string.Format(@"{0}\\SRTMacro.json", BaseDirectPath);

    }
}
