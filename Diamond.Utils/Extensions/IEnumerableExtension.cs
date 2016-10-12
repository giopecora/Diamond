using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class IEnumerableExtension
{
    public static List<D> ToDTO<E, D>(this IEnumerable<E> from)
    {
        List<D> lista = new List<D>();

        foreach (E item in from)
        {
            lista.Add((D)Activator.CreateInstance(typeof(D), item));
        }

        return lista;
    }
}
