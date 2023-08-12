using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerProModels
{
    /// <summary>
    /// 学员类
    /// </summary>
    public class ScoreList
    {
        /// <summary>
        /// 学员Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public int StudentId { get; set; }
        public int CSharp { get; set; }
        public int SQLServerDB { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
