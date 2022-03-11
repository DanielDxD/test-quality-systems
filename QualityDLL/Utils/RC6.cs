using System;

namespace Utils
{
    /**
    *
    *  RC6 (RC6 Algorithm)
    *  http://www.webtoolkit.info/
    *
    **/

    public class RC6
    {
        private UInt32[] sKey = new UInt32[44];
        private UInt32 BLOCK_SIZE = 16;

        private UInt32 MAX(UInt32 x, UInt32 y)
        {
            return (((x) > (y))? (x): (y));
        }

        private UInt32 MIN(UInt32 x, UInt32 y)
        {
            return (((x) < (y))? (x): (y));
        }

        private UInt32 BSWAP(UInt32 x)
        {
            return
            (
                ((x >> 24) & 0x000000FF) |
                ((x << 24) & 0xFF000000) |
                ((x >> 8) & 0x0000FF00) |
                ((x << 8) & 0x00FF0000)
            );
        }

        private UInt32 ROL(UInt32 x, UInt32 y)
        {
            return
            (
                (((x) << (((Int32)y) & 31)) |
                (((x) & 0xFFFFFFFF) >> (32 - (((Int32)y) & 31)))) & 0xFFFFFFFF
            );
        }

        private UInt32 ROR(UInt32 x, UInt32 y)
        {
            return
            (
                ((((x) & 0xFFFFFFFF) >> (((Int32)y) & 31)) |
                ((x) << (32 - (((Int32)y) & 31)))) & 0xFFFFFFFF
            );
        }

        private string STORE32(UInt32 x)
        {
            return
            (
                new string((char)((x) & 255), 1) +
                new string((char)(((x) >> 8) & 255), 1) +
                new string((char)(((x) >> 16) & 255), 1) +
                new string((char)(((x) >> 24) & 255), 1)
            );
        }

        private UInt32 ADD32(UInt32 x, UInt32 y)
        {
            UInt32 result = 0;

            for(int i = 0; i < 4; i++)
                result += ((((x >> (i * 8)) & 0x000000ff) + ((y >> (i * 8)) & 0x000000ff)) << (i * 8));

            return (result & 0xffffffff);
        }

        private UInt32 SUB32(UInt32 x, UInt32 y)
        {
            return ADD32(x, ADD32(~y, 1));
        }

        private UInt32 MUL32(UInt32 x, UInt32 y)
        {
            UInt32 result = 0;

            for(int iy = 0; iy < 4; iy++)
            {
                for(int ix = 0; ix < (4 - iy); ix++)
                    result += (((((x >> (ix * 8)) & 0x000000ff) * ((y >> (iy * 8)) & 0x000000ff))) << ((ix + iy) * 8));
            }

            return (result & 0xffffffff);
        }

        private UInt32 LOAD32(string y, int w)
        {
            return
            (
                (UInt32)
                (
                    ((y[((w * 4) + 0)] & 255)) |
                    ((y[((w * 4) + 1)] & 255) << 8) |
                    ((y[((w * 4) + 2)] & 255) << 16)  |
                    ((y[((w * 4) + 3)] & 255) << 24)
                )
            );
        }

        public void setup(string key)
        {
            UInt32[]    L = new UInt32[(key.Length + 3) / 4],
                        S = new UInt32[44];
            UInt32      A,
                        B,
                        i,
                        j,
                        v,
                        s,
                        t,
                        l;

            /* copy the key into the L array */
            for (A = i = j = 0; i < key.Length; )
            {
                A = (A << 8) | (UInt32)((key[(int)(i++)] & 255));

                if ((((int)i) & 3) == 0)
                {
                    L[j++] = BSWAP(A);
                    A = 0;
                }
                else{}
            }

            /* handle odd sized keys */
            if ((key.Length & 3) != 0)
            {
               A <<= (8 * (4 - (key.Length & 3)));
               L[j++] = BSWAP(A);
            }
            else{}

            /* setup the S array */
            t = 44; /* fixed at 20 rounds */
            S[0] = ADD32(0xB7E15163, 0);
            for (i = 1; i < t; i++)
                S[i] = ADD32(S[i - 1], 0x9E3779B9);

            /* mix buffer */
            s = 3 * MAX(t, j);
            l = j;
            
            for (A = B = i = j = v = 0; v < s; v++)
            {
                A = S[i] = ROL(ADD32(ADD32(S[i], A), B), 3);
                B = L[j] = ROL(ADD32(ADD32(L[j], A), B), ADD32(A, B));
                i = (i + 1) % t;
                j = (j + 1) % l;
            }

            /* copy to key */
            for (i = 0; i < t; i++)
                this.sKey[i] = S[i];
        }

        private string coreCrypt(string _string, Boolean decipher)
        {
            UInt32  a,
                    b,
                    c,
                    d,
                    t,
                    u;

            Int32   r;

            a = LOAD32(_string, 0);
            b = LOAD32(_string, 1);
            c = LOAD32(_string, 2);
            d = LOAD32(_string, 3);

            if (decipher)
            {
                a = SUB32(a, this.sKey[42]);
                c = SUB32(c, this.sKey[43]);

                for (r = 19; r >= 0; r--)
                {
                    t = d;
                    d = c;
                    c = b;
                    b = a;
                    a = t;
                    t = MUL32(b, ADD32(ADD32(b, b), 1));
                    t = ROL(t, 5);
                    u = MUL32(d, ADD32(ADD32(d, d), 1));
                    u = ROL(u, 5);
                    c = ROR(SUB32(c, this.sKey[r + r + 3]), t) ^ u;
                    a = ROR(SUB32(a, this.sKey[r + r + 2]), u) ^ t;
                }

                b = SUB32(b, this.sKey[0]);
                d = SUB32(d, this.sKey[1]);
            }
            else
            {
                b = ADD32(b, this.sKey[0]);
                d = ADD32(d, this.sKey[1]);

                for (r = 0; r < 20; r++)
                {
                    t = MUL32(b, ADD32(ADD32(b, b), 1));
                    t = ROL(t, 5);
                    u = MUL32(d, ADD32(ADD32(d, d), 1));
                    u = ROL(u, 5);
                    a = ADD32(ROL(a ^ t, u), this.sKey[r + r + 2]);
                    c = ADD32(ROL(c ^ u, t), this.sKey[r + r + 3]);
                    t = a;
                    a = b;
                    b = c;
                    c = d;
                    d = t;
                }

                a = ADD32(a, this.sKey[42]);
                c = ADD32(c, this.sKey[43]);
            }

            return
            (
                STORE32(a) +
                STORE32(b) +
                STORE32(c) +
                STORE32(d)
            );
        }

        public string encrypt(string _string)
        {
            string  result = "";

            for (int i = 0; i < _string.Length; i += (int)BLOCK_SIZE)
                result += coreCrypt(_string.Substring(i, (int)BLOCK_SIZE), false);

            return result;
        }

        public string encrypt(string _key, string _string)
        {
            this.setup(_key);

            return this.encrypt(_string);
        }

        public string decrypt(string _string)
        {
            string result = "";

            for (int i = 0; i < _string.Length; i += (int)BLOCK_SIZE)
                result += coreCrypt(_string.Substring(i, (int)BLOCK_SIZE), true);

            return result;
        }

        public string decrypt(string _key, string _string)
        {
            this.setup(_key);

            return this.decrypt(_string);
        }
    }
}
