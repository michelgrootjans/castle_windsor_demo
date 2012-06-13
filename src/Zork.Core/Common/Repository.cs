using System;

namespace Zork.Core.Common
{
    public class Repository<T>: IRepository<T>
    {
        public T FindById(int id)
        {
            Console.WriteLine("getting a {0} from the database", typeof(T));
            return default(T);
        }
    }
}