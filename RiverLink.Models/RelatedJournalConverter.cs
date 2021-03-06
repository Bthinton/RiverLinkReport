﻿using FileHelpers;
using System;
using System.Collections;
using System.Linq;

namespace RiverLink.Models
{

    public class RelatedJournalConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
            return from.Split(',').Select(x => Convert.ToInt32(x)).ToList();
        }

        public override string FieldToString(object fieldValue)
        {
            var result = ((IEnumerable)fieldValue).Cast<object>().ToList();
            return String.Join(",", result.Select(x => x.ToString()).ToArray());
        }

    }
}