using System;

namespace Zork.Core.Common
{
    public class FindByIdQuery<T>: IFindByIdQuery<T>
    {
        public T FindById(int id)
        {
            Console.WriteLine("getting a {0} from the database", typeof(T));
            return default(T);
        }
    }
}