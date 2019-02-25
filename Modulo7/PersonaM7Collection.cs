using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo7
{
    public class PersonaM7Collection : IEnumerable<PersonaM7>, IList<PersonaM7>
    {
        private int quantity;
        private const int cap_step = 3;
        private PersonaM7[] data;

        public PersonaM7 this[int index]
        {
            get
            {
                if (index >= quantity || index < 0)
                {
                    throw new ArgumentException("Indice fuera de rango");
                }
                else
                {
                    return data[index];
                }
            }
            set
            {
                if (index >= quantity || index < 0)
                {
                    throw new ArgumentException("Indice fuera de rango");
                }
                else
                {
                    data[index] = value;
                }
            }
        }

        public int Count
        {
            get
            {
                return quantity;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public PersonaM7Collection()
        {
            Clear();
        }

        public PersonaM7Collection(PersonaM7[] arr_personas) : base()
        {
            data = arr_personas;
        }

        private void ResizeData(bool expand)
        {
            int copy_pos = 0;
            PersonaM7[] tmp_buffer;

            if (expand)
            {
                tmp_buffer = new PersonaM7[quantity + cap_step];
                data.CopyTo(tmp_buffer, 0);
            }
            else
            {
                tmp_buffer = new PersonaM7[quantity];

                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] != null)
                    {
                        tmp_buffer[copy_pos++] = data[i];
                    }
                }
            }

            data = tmp_buffer;
        }

        public void Add(PersonaM7 item)
        {
            if (data.Length == quantity)
            {
                ResizeData(true);
            }

            data[quantity++] = item;
        }

        public void Clear()
        {
            quantity = 0;
            data = new PersonaM7[cap_step];
        }

        public bool Contains(PersonaM7 item)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Nombre == item.Nombre &&
                    data[i].Apellidos == item.Apellidos &&
                    data[i].DNI == item.DNI)
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(PersonaM7[] array, int arrayIndex)
        {
            data.CopyTo(array, arrayIndex);
        }

        public IEnumerator<PersonaM7> GetEnumerator()
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != null)
                {
                    yield return data[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(PersonaM7 item)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Nombre == item.Nombre &&
                    data[i].Apellidos == item.Apellidos &&
                    data[i].DNI == item.DNI)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, PersonaM7 item)
        {
            //Verificamos si hay espacio contando el elemento a insertar. Si no es así, redimensionamos matriz.
            if (quantity + 1 > data.Length)
            {
                ResizeData(true);
            }

            //Indice dentro de rango
            if (index < data.Length &&
                index >= 0)
            {
                //Desplazamos una posición hacia arriba hasta llegar al punto donde debemos insertar el valor
                for (int i = data.Length - 1; i > index; i--)
                {
                    data[i] = data[i - 1];
                }

                //Insertamos y aumentamos contador
                data[index] = item;
                quantity++;
            }
            else
            {
                throw new ArgumentException("Indice fuera de rango");
            }
        }

        public bool Remove(PersonaM7 item)
        {
            int pos = IndexOf(item);

            if (pos == -1)
            {
                return false;
            }
            else
            {
                data[pos] = null;
                quantity--;

                ResizeData(false);
                return true;
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 || index <= quantity - 1)
            {
                data[index] = null;
                quantity--;

                ResizeData(false);
            }
            else
            {
                throw new ArgumentException("Indice fuera de rango");
            }
        }
    }
}
