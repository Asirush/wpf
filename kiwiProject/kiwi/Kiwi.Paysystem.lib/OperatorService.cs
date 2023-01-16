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
            catch (Exception)
            {
                return false;
            }

        }
    }
}
