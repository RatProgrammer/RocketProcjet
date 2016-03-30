using WPFP.CommunicationLayer.DTO;
using WPFP.CommunicationLayer.Enums;
using WPFP.CommunicationLayer.Interfaces;
using WPFP.Core.ParsingStuff;
using WPFP.Psyche.StateMachine;
using WPFP.Psyche.StateMachine.DomainListener.Primary.Research;

namespace WPFP.Core
{
    public class AfterLaunchScoringMechanism : IAfterLaunchEvent
    {
        private ScoringMechanism _scoringMechanism;

        public AfterLaunchScoringMechanism(ScoringMechanism scoringMechanism)
        {
           
            _scoringMechanism = scoringMechanism;
           
        }

        public void Launch()
        {
            GoalType goalType = _scoringMechanism.GoalType();
            bool wasSomeKingOfEventPublished = _scoringMechanism.WasEventPublished("someKindOfEvent");
            _scoringMechanism.Increase(15);

         
        }
       
    }
    
}
