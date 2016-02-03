using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ChangeTime
{

    [XmlRoot(ElementName = "table")]
    public class Table
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "set")]
    public class Set
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "val")]
        public string Val { get; set; }
    }

    [XmlRoot(ElementName = "enchant1")]
    public class Enchant1
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "val")]
        public string Val { get; set; }
    }

    [XmlRoot(ElementName = "param")]
    public class Param
    {
        [XmlAttribute(AttributeName = "power")]
        public string Power { get; set; }
        [XmlAttribute(AttributeName = "dispel")]
        public string Dispel { get; set; }
        [XmlAttribute(AttributeName = "BLEED")]
        public string BLEED { get; set; }
        [XmlAttribute(AttributeName = "POISON")]
        public string POISON { get; set; }
        [XmlAttribute(AttributeName = "chance")]
        public string Chance { get; set; }
        [XmlAttribute(AttributeName = "HOLD")]
        public string HOLD { get; set; }
        [XmlAttribute(AttributeName = "SLEEP")]
        public string SLEEP { get; set; }
        [XmlAttribute(AttributeName = "DERANGEMENT")]
        public string DERANGEMENT { get; set; }
        [XmlAttribute(AttributeName = "escapeType")]
        public string EscapeType { get; set; }
        [XmlAttribute(AttributeName = "slot")]
        public string Slot { get; set; }
        [XmlAttribute(AttributeName = "rate")]
        public string Rate { get; set; }
        [XmlAttribute(AttributeName = "max")]
        public string Max { get; set; }
    }

    [XmlRoot(ElementName = "add")]
    public class Add
    {
        [XmlAttribute(AttributeName = "stat")]
        public string Stat { get; set; }
        [XmlAttribute(AttributeName = "val")]
        public string Val { get; set; }
    }

    [XmlRoot(ElementName = "effect")]
    public class Effect
    {
        [XmlElement(ElementName = "param")]
        public List<Param> Param { get; set; }
        [XmlElement(ElementName = "add")]
        public Add Add { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "ticks")]
        public string Ticks { get; set; }
        [XmlElement(ElementName = "mul")]
        public List<Mul> Mul { get; set; }
        [XmlElement(ElementName = "sub")]
        public List<Sub> Sub { get; set; }
    }

    [XmlRoot(ElementName = "for")]
    public class For
    {
        [XmlElement(ElementName = "effect")]
        public List<Effect> Effect { get; set; }
    }

    [XmlRoot(ElementName = "enchant1for")]
    public class Enchant1for
    {
        [XmlElement(ElementName = "effect")]
        public List<Effect> Effect { get; set; }
    }

    [XmlRoot(ElementName = "skill")]
    public class Skill
    {
        [XmlElement(ElementName = "table")]
        public List<Table> Table { get; set; }
        [XmlElement(ElementName = "set")]
        public List<Set> Set { get; set; }
        [XmlElement(ElementName = "enchant1")]
        public List<Enchant1> Enchant1 { get; set; }
        [XmlElement(ElementName = "for")]
        public For For { get; set; }
        [XmlElement(ElementName = "enchant1for")]
        public Enchant1for Enchant1for { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "levels")]
        public string Levels { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "enchantGroup1")]
        public string EnchantGroup1 { get; set; }
        [XmlElement(ElementName = "enchant2")]
        public List<Enchant2> Enchant2 { get; set; }
        [XmlAttribute(AttributeName = "enchantGroup2")]
        public string EnchantGroup2 { get; set; }
        [XmlElement(ElementName = "cond")]
        public Cond Cond { get; set; }
        [XmlElement(ElementName = "enchant3")]
        public List<Enchant3> Enchant3 { get; set; }
        [XmlAttribute(AttributeName = "enchantGroup3")]
        public string EnchantGroup3 { get; set; }
        [XmlElement(ElementName = "enchant3for")]
        public Enchant3for Enchant3for { get; set; }
    }

    [XmlRoot(ElementName = "enchant2")]
    public class Enchant2
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "val")]
        public string Val { get; set; }
    }

    [XmlRoot(ElementName = "mul")]
    public class Mul
    {
        [XmlAttribute(AttributeName = "stat")]
        public string Stat { get; set; }
        [XmlAttribute(AttributeName = "val")]
        public string Val { get; set; }
    }

    [XmlRoot(ElementName = "target")]
    public class Target
    {
        [XmlAttribute(AttributeName = "active_skill_id")]
        public string Active_skill_id { get; set; }
        [XmlAttribute(AttributeName = "race")]
        public string Race { get; set; }
    }

    [XmlRoot(ElementName = "not")]
    public class Not
    {
        [XmlElement(ElementName = "target")]
        public Target Target { get; set; }
        [XmlElement(ElementName = "player")]
        public Player Player { get; set; }
    }

    [XmlRoot(ElementName = "cond")]
    public class Cond
    {
        [XmlElement(ElementName = "not")]
        public Not Not { get; set; }
        [XmlAttribute(AttributeName = "msgId")]
        public string MsgId { get; set; }
        [XmlAttribute(AttributeName = "addName")]
        public string AddName { get; set; }
        [XmlElement(ElementName = "player")]
        public Player Player { get; set; }
        [XmlElement(ElementName = "target")]
        public Target Target { get; set; }
        [XmlElement(ElementName = "and")]
        public And And { get; set; }
    }

    [XmlRoot(ElementName = "player")]
    public class Player
    {
        [XmlAttribute(AttributeName = "canResurrect")]
        public string CanResurrect { get; set; }
        [XmlAttribute(AttributeName = "canEscape")]
        public string CanEscape { get; set; }
        [XmlAttribute(AttributeName = "insideZoneId")]
        public string InsideZoneId { get; set; }
    }

    [XmlRoot(ElementName = "enchant3")]
    public class Enchant3
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "val")]
        public string Val { get; set; }
    }

    [XmlRoot(ElementName = "enchant3for")]
    public class Enchant3for
    {
        [XmlElement(ElementName = "effect")]
        public List<Effect> Effect { get; set; }
    }

    [XmlRoot(ElementName = "and")]
    public class And
    {
        [XmlElement(ElementName = "player")]
        public Player Player { get; set; }
        [XmlElement(ElementName = "not")]
        public Not Not { get; set; }
    }

    [XmlRoot(ElementName = "sub")]
    public class Sub
    {
        [XmlAttribute(AttributeName = "stat")]
        public string Stat { get; set; }
        [XmlAttribute(AttributeName = "val")]
        public string Val { get; set; }
    }

    [XmlRoot(ElementName = "list")]
    public class List
    {
        [XmlElement(ElementName = "skill")]
        public List<Skill> Skill { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "noNamespaceSchemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string NoNamespaceSchemaLocation { get; set; }
    }
}
