
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common
{
    public class Question
    {

        [XmlAttribute("Id")]
        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        [XmlAttribute("Type")]
        public AnswerType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        [XmlElement("SpecificQuestion")]
        public string SpecificQuestion
        {
            get
            {
                return specificQuestion;
            }

            set
            {
                specificQuestion = value;
            }
        }

        [XmlArray("Answers")]
        [XmlArrayItem("Answer")]
        public List<string> Answers
        {
            get
            {
                return _answers;
            }

            set
            {
                _answers = value;
            }
        }

        [XmlIgnore]
        public string ShowAnswers
        {
            get
            {
                string result = string.Empty;

                Answers.ForEach(A =>
                {
                    result += A + "\r\n";
                });
                return result.Contains("\r\n") ? result.Substring(0, result.LastIndexOf("\r\n")) : result;
            }
        }

        [XmlIgnore]
        public string SubmitAnswer
        {
            get
            {
                return _submitAnswer;
            }

            set
            {
                _submitAnswer = value;
            }
        }

        private string id;

        private AnswerType type;

        private string specificQuestion;

        private List<string> _answers = new List<string>();

        private string _submitAnswer;
    }

    public class QuestionList
    {

        [XmlArray("Questions")]
        public List<Question> Questions
        {
            get
            {
                return questions;
            }

            set
            {
                questions = value;
            }
        }

        [XmlElement("ReceivingMail")]
        public string ReceivingMail
        {
            get
            {
                return receivingMail;
            }

            set
            {
                receivingMail = value;
            }
        }

        private List<Question> questions = new List<Question>();

        private string receivingMail;
    }
}
