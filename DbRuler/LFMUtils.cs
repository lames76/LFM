using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRuler
{
    /// <summary>
    /// This is the AgeClass of a character. It have two "special" values: Timelord and Elf.
    /// Timelord means it is not yet born, Elf meand it is older than 100 years.
    /// </summary>
    public enum AgeClass
    {
        NoValue = 0,
        Timelord = 10,
        Child = 1,
        Teen = 2,
        Average = 3,
        Mature = 4,
        Old = 5,
        Elf = 11
    }

    public static class LFMUtils
    {
        /// <summary>
        /// This method check the current Age (year) with another age (year) and return
        /// the AgeClass (enum).
        /// </summary>
        /// <param name="intCurrentAge"></param>
        /// <param name="intReferralAge"></param>
        /// <returns></returns>
        public static AgeClass GetAgeClassFromDate(int intCurrentAge, int intReferralAge)
        {
            int intAppo = intCurrentAge - intReferralAge;
            if (intAppo < 0)
                return AgeClass.Timelord;
            if (intAppo > 100)
                return AgeClass.Elf;
            if (intAppo < 15)
                return AgeClass.Child;
            if (intAppo < 30)
                return AgeClass.Teen;
            if (intAppo < 45)
                return AgeClass.Average;
            if (intAppo < 70)
                return AgeClass.Mature;
            return AgeClass.Old;
        }


    }
}
