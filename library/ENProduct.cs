using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        public string Code{
            get
            {
                return _code;
            }

            set
            {
                _code = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int Amount
        {
            get
            {
                return _amount;
            }

            set
            {
                _amount = value;
            }
        }

        public float Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }

        public int Category
        {
            get
            {
                return _category;
            }

            set
            {
                _category = value;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return _creationDate;
            }

            set
            {
                _creationDate = value;
            }
        }

        public ENProduct()
        {

        }

        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            this.Code = code;
            this.Name = name;
            this.Amount = amount;
            this.Category = category;
            this.CreationDate = creationDate;
            this.Price = price;

        }

        public bool Create()
        {
            try
            {


                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {


                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete()
        {
            try
            {


                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Read()
        {
            try
            {


                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ReadFirst()
        {
            try
            {


                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ReadNext()
        {
            try
            {


                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ReadPrev()
        {
            try
            {


                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
