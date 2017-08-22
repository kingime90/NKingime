using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Module
    {
        /// <summary>
        /// 子模块列表
        /// </summary>
        [NotMapped]
        public List<Module> Childs { get; set; }
    }
}
