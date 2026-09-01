using Isteyap.Core.Application.Results.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Results
{
    public class ResultDataControl<T> : ResultControlBase, IResultDataControl<T>
    {
        public ResultDataControl()
        {

        }

        public ResultDataControl(T d)
        {
            this._data = d;
        }

        private T _data;
        public T Data => _data;

        public object GetDataObject()
        {
            return this.Data;
        }

        public IResultDataControl<T> SetData(T t)
        {
            _data = t;
            return this;
        }

        public IResultDataControl<T> SuccessSetData(T t)
        {
            this.SetData(t);
            base.Success();
            return this;
        }

        public IResultDataControl<T> Fail(Exception exception)
        {
            base.Fail(exception);
            return this;
        }

        public IResultDataControl<T> Fail()
        {
            base.Fail();
            return this;
        }

        public static IResultDataControl<T> CreateSuccess(T data)
        {
            if (data!=null)
            {
                return new ResultDataControl<T>().SuccessSetData(data);
            }
            return new ResultDataControl<T>().SuccessSetData(default(T));
        }



        public static IResultDataControl<T> FailError(Exception exception = null)
        {
            if (exception != null)
            {
                return new ResultDataControl<T>().Fail(exception);
            }

            return new ResultDataControl<T>().Fail();
        }

    }
}
