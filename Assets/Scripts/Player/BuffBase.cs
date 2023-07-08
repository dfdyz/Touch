using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player
{
    public abstract class BuffBase
    {
        private int level;
        private float time;
        public BuffBase(int level, float time)
        {
            this.level = level;
            this.time = time;
        }

        public int getLevel()
        {
            return level;
        }

        public float getTime()
        {
            return time;
        }

        public virtual float value()
        {
            return 0;
        }

        public virtual void OnUpdate()
        {

        }
        public virtual void OnRemove()
        {

        }

        public void upd(float dt)
        {
            OnUpdate();
            time -= dt;
        }

        public bool isAlive()
        {
            return time > 0;
        }

        public class HeavyMassBuff : BuffBase
        {
            public HeavyMassBuff(int level, float time) : base(level, time)
            {
                this.level = level;
            }

            public override float value()
            {
                return 10 + 5 * level;
            }
        }

        public class HighSpeedBuff : BuffBase
        {
            public HighSpeedBuff(int level, float time) : base(level, time)
            {
                this.level = level;
            }

            public override float value()
            {
                return 10 + 5 * level;
            }
        }

        public class LowStunBuff : BuffBase
        {
            public LowStunBuff(int level, float time) : base(level, time)
            {
                this.level = level;
            }

            public override float value()
            {
                return -0.3f*level;
            }
        }

    }
}
