using System;

namespace GameFiles.Scripts.plain.objects
{
    public class CoolingDownEntity
    {
        private int _quantity;
        private bool _coolingDown;

        public CoolingDownEntity(int quantity)
        {
            _quantity = quantity;
        }

        public void Use()
        {
            if (!CanUse())
            {
                throw new SystemException("Can't use it right now");
            }

            _quantity--;
            _coolingDown = true;
        }

        public bool CanUse()
        {
            return _quantity != 0 && !_coolingDown;
        }

        public void StopCoolDown()
        {
            _coolingDown = false;
        }

        public int GetQuantity()
        {
            return _quantity;
        }
    }
}