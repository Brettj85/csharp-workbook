using System;
using System.Collections.Generic;
using System.IO;

namespace WordGuess
{

    class CheckEquality
    {
        enum Letters
        {
            a,
            b,
            c,
            d,
            e,
            f,
            g,
            h,
            i,
            j,
            k,
            l,
            m,
            n,
            o,
            p,
            q,
            r,
            s,
            t,
            u,
            v,
            w,
            x,
            y,
            z,
        }
        public string compareTwo(string guess, string answer)
        {
            string result = "";
            if (guess.ToLower() == answer.ToLower())
            {
                result = "Correct ";
            }
            else if (answer.Length > guess.Length)
            {
                result = "Lower";
                for (int i = 0; i < guess.Length; i++)
                {
                    if (guess[i] != answer[i])
                    {
                        int toGuess = (int)System.Enum.Parse(typeof(Letters), answer.Substring(i, 1).ToLower());
                        int fromGuess = (int)System.Enum.Parse(typeof(Letters), guess.Substring(i, 1).ToLower());
                        if (fromGuess > toGuess)
                        {
                            result = "Higher";
                        }
                        else if (fromGuess < toGuess)
                        {
                            result = "Lower";
                        }
                        break;
                    }
                }
            }
            else if (answer.Length < guess.Length)
            {
                result = "Higher";
                for (int i = 0; i < answer.Length; i++)
                {
                    if (guess[i] != answer[i])
                    {
                        int toGuess = (int)System.Enum.Parse(typeof(Letters), answer.Substring(i, 1).ToLower());
                        int fromGuess = (int)System.Enum.Parse(typeof(Letters), guess.Substring(i, 1).ToLower());
                        if (fromGuess > toGuess)
                        {
                            result = "Higher";
                        }
                        else if (fromGuess < toGuess)
                        {
                            result = "Lower";
                        }
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < answer.Length; i++)
                {
                    if (guess[i] != answer[i])
                    {
                        int toGuess = (int)System.Enum.Parse(typeof(Letters), answer.Substring(i, 1).ToLower());
                        int fromGuess = (int)System.Enum.Parse(typeof(Letters), guess.Substring(i, 1).ToLower());
                        if (fromGuess > toGuess)
                        {
                            result = "Higher";
                        }
                        else if (fromGuess < toGuess)
                        {
                            result = "Lower";
                        }
                        break;
                    }
                }
            }
            return result;
        }
    }
}