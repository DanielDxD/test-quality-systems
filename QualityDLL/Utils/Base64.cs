using System;

namespace Utils
{
    public class Base64
    {
	    // private property
	    private string keyStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

        // public method for encoding
	    public string encode(string input)
        {
		    string output = "";
		    byte chr1 = 0, chr2 = 0, chr3 = 0, enc1 = 0, enc2 = 0, enc3 = 0, enc4 = 0;
		    int i = 0;

		    while (i < input.Length)
            {
			    chr1 = (byte)input[(i++)];
                enc1 = (byte)(chr1 >> 2);
                if (i < input.Length)
                {
                    chr2 = (byte)input[(i++)];
                    enc2 = (byte)(((chr1 & 3) << 4) | (chr2 >> 4));

                    if (i < input.Length)
                    {
                        chr3 = (byte)input[(i++)];
                        enc3 = (byte)(((chr2 & 15) << 2) | (chr3 >> 6));
                        enc4 = (byte)(chr3 & 63);
                    }
                    else
                        enc4 = 64;
                }
                else
                {
                    enc2 = (byte)(((chr1 & 3) << 4));
                    enc3 = enc4 = 64;
                }

			    output +=
                (
                    new string((char)this.keyStr[(enc1)], 1) +
                    new string((char)this.keyStr[(enc2)], 1) +
                    new string((char)this.keyStr[(enc3)], 1) +
                    new string((char)this.keyStr[(enc4)], 1)
                );
		    }

		    return output;
	    }

	    // public method for decoding
	    public string decode(string input)
        {
		    string output = "";
		    byte chr1, chr2, chr3;
		    byte enc1, enc2, enc3, enc4;
		    int i = 0;

		    input = input.Replace("/[^A-Za-z0-9\\+\\/\\=]/g", "");

		    while (i < input.Length)
            {
                enc1 = (byte)this.keyStr.IndexOf(input[(i++)]);
                enc2 = (byte)this.keyStr.IndexOf(input[(i++)]);
                enc3 = (byte)this.keyStr.IndexOf(input[(i++)]);
                enc4 = (byte)this.keyStr.IndexOf(input[(i++)]);

                chr1 = (byte)((enc1 << 2) | (enc2 >> 4));
                chr2 = (byte)(((enc2 & 15) << 4) | (enc3 >> 2));
			    chr3 = (byte)(((enc3 & 3) << 6) | enc4);

			    output = output + new string((char)chr1, 1);

                if (enc3 != 64)
                    output = output + new string((char)chr2, 1);
                else { }

                if (enc4 != 64)
                    output = output + new string((char)chr3, 1);
                else { }
		    }

		    return output;
	    }
    }
}
