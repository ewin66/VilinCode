namespace JF.Common.Libary.NHibernate
{
    public class CriteriaParameter
    {
        private string _propertyName;
        private string _tableName;
        private object _value1;
        private object _value2;
        private object[] _values;
        private CriteriaOperator _criteriaOperator;

        public CriteriaParameter(string propertyName, object value1, CriteriaOperator criteriaOperator)
            : this(propertyName, value1, null, criteriaOperator) { }

        public CriteriaParameter(string propertyName, CriteriaOperator criteriaOperator)
            : this(propertyName, null, null, criteriaOperator) { }

        private CriteriaParameter(string propertyName, object value1, object value2, CriteriaOperator criteriaOperator)
        {
            this._propertyName = propertyName;
            this._value1 = value1;
            this._value2 = value2;
            this._criteriaOperator = criteriaOperator;
        }

        ///<summary>
        /// 关联CriteriaOperator.In or NotIn测试
        ///</summary>
        ///<param name="propertyName"></param>
        ///<param name="values"></param>
        public CriteriaParameter(string tableName, string propertyName, object[] values, CriteriaOperator criteriaOperator)
        {
            this._propertyName = propertyName;
            this._values = values;
            this._tableName = tableName;
            this._criteriaOperator = criteriaOperator;
        }

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }

        public object Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }

        public object Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }

        public object[] Values
        {
            get { return _values; }
            set { _values = value; }
        }

        public CriteriaOperator CriteriaOperator
        {
            get { return _criteriaOperator; }
            set { _criteriaOperator = value; }
        }
    }

    public enum CriteriaOperator
    {
        Eq = 1,
        Gt = 2,
        Lt = 3,
        Between = 4,
        LikeLeft = 5,
        In = 6,
        On = 7,
        IsNotNullOrEmpty = 8,
        IsNullOrEmpty = 9,
        Or = 10,
        Le = 11,
        Ge = 12,
        NotEq = 13,
        OrderByDesc = 14,
        OrderByAsc = 15,
        LikeRight = 16,
        LikeLeftRight = 17,
        NotIn = 18
    }
}