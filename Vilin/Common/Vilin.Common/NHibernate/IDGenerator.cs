using System;
using System.Collections.Generic;
using NHibernate.Id;

namespace JF.Common.Libary.NHibernate
{
    public class IDGenerator : IIdentifierGenerator, IConfigurable
    {
        private IDictionary<string, string> parameters = new Dictionary<string, string>();

        #region IIdentifierGenerator Members

        object IIdentifierGenerator.Generate(global::NHibernate.Engine.ISessionImplementor session, object obj)
        {
            try
            {
                string algorithm = "Segment";
                string tableName = parameters[global::NHibernate.Id.PersistentIdGeneratorParmsNames.Table];

                if (parameters.ContainsKey("algorithm"))
                {
                    algorithm = parameters["algorithm"];
                }

                if (parameters.ContainsKey("table"))
                {
                    tableName = parameters["table"];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion IIdentifierGenerator Members

        #region IConfigurable Members

        void IConfigurable.Configure(global::NHibernate.Type.IType type, IDictionary<string, string> parms, global::NHibernate.Dialect.Dialect d)
        {
            try
            {
                parameters = parms;
            }
            catch (Exception ex)
            {
                //throw new NotImplementedException();
                throw ex;
            }
        }

        #endregion IConfigurable Members
    }
}