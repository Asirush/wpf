using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiwi.Paysystem.lib
{
    public class OperatorService
    {
        EntityModel db = new EntityModel();
        public List<Operators> GetOperators()
        {
            List<Operators> operators = new List<Operators>();
            operators = db.Operators.ToList();
            return operators;
        }

        public bool AddOperator(Operators operators)
        {
            try
            {
                db.Operators.Add(operators);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        public bool EditOperator(Operators _oper)
        {
            try
            {
                var oper = db.Operators.Find(_oper.Id);
                oper.Id = _oper.Id;
                oper.Logo = _oper.Logo;
                oper.Name = _oper.Name;
                oper.Phone = _oper.Phone;
                oper.Precent = _oper.Precent;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
