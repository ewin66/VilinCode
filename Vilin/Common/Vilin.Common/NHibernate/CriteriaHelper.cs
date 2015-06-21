using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace JF.Common.Libary.NHibernate
{
    public class CriteriaHelper
    {
        private static ICriteria AddCriteria(CriteriaParameter criteriaParameter, CriteriaOperator criteriaOperator, ICriteria criteria)
        {
            //CriteriaOperator.IsNullOrEmpty
            if (criteriaOperator == CriteriaOperator.IsNullOrEmpty)
            {
                if (criteriaParameter.Value1 == null)
                {
                    criteria.Add(Expression.IsNull(criteriaParameter.PropertyName));
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(criteriaParameter.Value1 as string))
                    {
                        criteria.Add(Expression.IsEmpty(criteriaParameter.PropertyName));
                    }
                }
            }
            //CriteriaOperator.IsNotNullOrEmpty
            if (criteriaOperator == CriteriaOperator.IsNotNullOrEmpty)
            {
                if (criteriaParameter.Value1 != null)
                {
                    if (!string.IsNullOrWhiteSpace(criteriaParameter.Value1 as string))
                    {
                        criteria.Add(Expression.IsNotEmpty(criteriaParameter.PropertyName));
                    }
                }
                else
                {
                    criteria.Add(Expression.IsNotNull(criteriaParameter.PropertyName));
                }
            }
            return criteria;
        }

        ///<summary>
        /// 初始化ICriteria对象
        ///</summary>
        public static ICriteria InitCriteria(ICriteria criteria, IList<CriteriaParameter> query)
        {
            foreach (var item in query)
            {
                switch (item.CriteriaOperator)
                {
                    case CriteriaOperator.Eq:
                        criteria.Add(Expression.Eq(item.PropertyName, item.Value1));
                        break;

                    case CriteriaOperator.LikeRight:
                        criteria.Add(Expression.Like(item.PropertyName,
                            String.Format("{0}%", item.Value1)));
                        break;

                    case CriteriaOperator.LikeLeft:
                        criteria.Add(Expression.Like(item.PropertyName,
                            String.Format("%{0}", item.Value1)));
                        break;

                    case CriteriaOperator.LikeLeftRight:
                        criteria.Add(Expression.Like(item.PropertyName,
                            String.Format("%{0}%", item.Value1)));
                        break;

                    case CriteriaOperator.Gt:
                        criteria.Add(Expression.Gt(item.PropertyName, item.Value1));
                        break;

                    case CriteriaOperator.Lt:
                        criteria.Add(Expression.Lt(item.PropertyName, item.Value1));
                        break;

                    case CriteriaOperator.Between:
                        criteria.Add(Expression.Between(item.PropertyName, item.Value1, item.Value2));
                        break;

                    case CriteriaOperator.In:
                        criteria.Add(Expression.In(item.PropertyName, item.Values));
                        break;

                    case CriteriaOperator.NotIn://这里的管理怎么封装？
                        if (item.TableName != "")
                            criteria.CreateCriteria(item.TableName, JoinType.InnerJoin).Add(Expression.Not(Expression.In(item.PropertyName, item.Values)));
                        break;

                    case CriteriaOperator.IsNullOrEmpty:
                        AddCriteria(item, CriteriaOperator.IsNullOrEmpty, criteria);
                        break;

                    case CriteriaOperator.IsNotNullOrEmpty:
                        AddCriteria(item, CriteriaOperator.IsNullOrEmpty, criteria);
                        break;

                    case CriteriaOperator.Le:
                        criteria.Add(Expression.Le(item.PropertyName, item.Value1));
                        break;

                    case CriteriaOperator.Ge:
                        criteria.Add(Expression.Ge(item.PropertyName, item.Value1));
                        break;

                    case CriteriaOperator.OrderByDesc:
                        criteria.AddOrder(Order.Desc(item.PropertyName));
                        break;

                    case CriteriaOperator.OrderByAsc:
                        criteria.AddOrder(Order.Asc(item.PropertyName));
                        break;
                }
            }
            return criteria;
        }
    }
}