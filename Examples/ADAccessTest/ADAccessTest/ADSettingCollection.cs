using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADAccessTest
{
    public class ADSettingCollection : CollectionBase
    {
        public ADSettingCollection() { }
        public ADSettingCollection(ADSettingCollection value)
        {
            this.AddRange(value);
        }
        public ADSettingCollection(ADSetting[] value)
        {
            this.AddRange(value);
        }
        public ADSetting GetADSetting(string name)
        {
            for (int i = 0; i < List.Count; i++)
            {
                ADSetting ds = (ADSetting)List[i];
                if (ds.Name == name)
                    return ds;

            }
            return null;
        }
        public ADSetting GetDefaultADSetting()
        {
            for (int i = 0; i < List.Count; i++)
            {
                ADSetting ds = (ADSetting)List[i];
                if (ds.IsDefault)
                    return ds;

            }

            throw new Exception("Cannot find default AD setting.");
        }
        public ADSettingCollection ADSettings()
        {
            ADSettingCollection dsc = new ADSettingCollection();
            for (int i = 0; i < List.Count; i++)
            {
                ADSetting ds = (ADSetting)List[i];
                dsc.Add(ds);
            }
            return dsc;
        }
        public ADSetting this[int index]
        {
            get { return ((ADSetting)(List[index])); }
            set { List[index] = value; }
        }
        public int Add(ADSetting value)
        {
            return List.Add(value);
        }
        public void AddRange(ADSetting[] value)
        {
            for (int Counter = 0; (Counter < value.Length); Counter = (Counter + 1))
            {
                this.Add(value[Counter]);
            }
        }
        public void AddRange(ADSettingCollection value)
        {
            for (int Counter = 0; (Counter < value.Count); Counter = (Counter + 1))
            {
                this.Add(value[Counter]);
            }
        }
        public bool Contains(ADSetting value)
        {
            return List.Contains(value);
        }
        public void CopyTo(ADSetting[] array, int index)
        {
            List.CopyTo(array, index);
        }
        public int IndexOf(ADSetting value)
        {
            return List.IndexOf(value);
        }
        public void Insert(int index, ADSetting value)
        {
            List.Insert(index, value);
        }
        new public ADSettingEnumerator GetEnumerator()
        {
            return new ADSettingEnumerator(this);
        }
        public void Remove(string dsName)
        {
            for (int i = 0; i < List.Count; i++)
            {
                ADSetting ds = (ADSetting)List[i];
                if (ds.Name == dsName)
                {
                    List.Remove(ds);
                }
            }
        }
        public void Remove(ADSetting value)
        {
            List.Remove(value);
        }

        public class ADSettingEnumerator : object, IEnumerator
        {
            private IEnumerator Base;
            private IEnumerable Local;
            public ADSettingEnumerator(ADSettingCollection Mappings)
            {
                this.Local = Mappings;
                this.Base = Local.GetEnumerator();
            }

            public ADSetting Current
            {
                get { return ((ADSetting)(Base.Current)); }
            }

            object IEnumerator.Current
            {
                get { return Base.Current; }
            }

            public bool MoveNext()
            {
                return Base.MoveNext();
            }
            bool IEnumerator.MoveNext()
            {
                return Base.MoveNext();
            }
            public void Reset()
            {
                Base.Reset();
            }
            void IEnumerator.Reset()
            {
                Base.Reset();
            }
        }
    }
}
