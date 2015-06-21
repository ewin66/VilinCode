using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Vilin.Models
{
    public abstract class EntityBase<TKey>
    {
        #region 构造函数

        /// <summary>
        ///     数据实体基类
        /// </summary>
        protected EntityBase()
        {
            State = 1;
            CreateDate = DateTime.Now;
        }

        #endregion

        #region 属性

        public TKey Id { get; set; }

        /// <summary>
        ///     获取或设置 获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        public int State { get; set; }

        /// <summary>
        ///     获取或设置 添加时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        #endregion
    }
}
