using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEx
{
    class myclass
    {
        private int value;//声明value私有字段
        public int Value//声明只读属性
        {
            get { return value; }
        }
        public myclass(int value)//构造函数
        {
            this.value = value;
        }

        public static explicit operator int(myclass mc)//显示声明的myclass转int类处理方法
        {
            return mc.value;
        }
        public static implicit operator myclass(int value)//隐式声明的int转myclass类处理方法
        {
            return new myclass(value);
        }
        public static implicit operator string(myclass mc)//隐式声明的myclass转string类处理方法
        {
            return ("定义的myclass类string类型转化结果");
        }
    }
}
