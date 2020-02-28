using System;
namespace BarberShop.Services
{
    public class Guards
    {
        private static GuardInvoker invoker = new GuardInvoker();

        public static GuardInvoker Require(object o, string msg) =>
          invoker.Require(o, msg);

        public static GuardInvoker Require(params (object value, string errorMessage)[] args) =>
          invoker.Require(args);

        public static GuardInvoker ThrowIf(bool condition, string msg) =>
          invoker.ThrowIf(condition, msg);

        public static GuardInvoker ThrowIf(params (bool condition, string errorMessage)[] args) =>
          invoker.ThrowIf(args);

    }

    public class GuardInvoker
    {
        public GuardInvoker Require(object o, string msg)
        {
            if (o is string s && string.IsNullOrWhiteSpace(s))
                throw new ArgumentException(msg);

            if (o == null)
                throw new ArgumentException(msg);

            return this;
        }

        public GuardInvoker Require(params (object value, string errorMessage)[] args)
        {
            foreach (var a in args)
                Require(a.value, a.errorMessage);

            return this;
        }

        public GuardInvoker ThrowIf(bool condition, string msg)
        {
            if (condition)
                throw new ArgumentException(msg);

            return this;
        }

        public GuardInvoker ThrowIf(params (bool condition, string errorMessage)[] args)
        {
            foreach (var a in args)
                ThrowIf(a.condition, a.errorMessage);

            return this;
        }
    }
}
