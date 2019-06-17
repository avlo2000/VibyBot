using System.Collections.Generic;

namespace VibyBot.Persistence.DTO
{
    public class Answer
    {
        public Order CurrentOrder { get; set; }

        public enum State
        {
            AdminAnswer, OrderAnswer
        }

        private State _state;

        private List<string> _buttoms;

        public string Text { private set; get; }
        public List<string> Buttoms
        {
            private set { _buttoms = value; }
            get { if (_state == State.OrderAnswer) return _buttoms; else return null; }
        }

        public Answer(string text)
        {
            Text = text;
            _state = State.AdminAnswer;
        }

        public Answer(string text, List<string> buttoms)
        {
            _state = State.OrderAnswer;
            Buttoms = buttoms;
            Text = text;
        }
    }
}
