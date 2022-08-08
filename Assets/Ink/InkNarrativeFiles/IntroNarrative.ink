VAR Ego = 0
VAR TeamMorale = 0

"Morning Sam, thanks for coming to see me." #The Doc

* "No problem Doc, what can I do you for?"

"We need to discuss your condition Sam. You took a nasty hit at the end of the semi-final and you failed your HIA." #The Doc
    
    ** "It was a tough one Doc, but I've been training with the team all week and I'm feeling back at my best."
    
    "I've seen the effort you've been putting in Sam, but we need to take this seriously. We're seeing, more and more, the long term effects that these injuries are having on players." #The Doc
    
        *** "I promise, I am taking this seriously. I'm confident that I can come through this for the team and join them on the pitch tomorrow."
        
        "I'm glad you're not taking it lightly Sam, but you have to consider your own health. I'm not sure playing would be the right move." #The Doc
        
            **** "I am! It's not just the right move for me but for the team. I want to be out there with them."
            
            "You're determination is admirable Sam, but it doesn't change my professional opinion. I'll be making my recommendation to the gaffer, you'll have to take it up with them." #The Doc
            
                ***** "I'm dissapointed Doc but I understand. I'll have a chat with Coach."
            
                "Glad we had this chat Sam, see you around." #The Doc
                
                -> Full_TM_Buffs
    
        *** "Believe me, I understand the seriousness Doc, but nothing is going to stop me from being a part of the Final."
        
        "I'm afraid that might not be true Sam. I don't know if I can sign off on this, with the risks involved." #The Doc
        
            **** "Please Doc, our whole season has been building toward this, you can't take it away from me now."
            
            "I know how hard you and team have been working but I have to think about what's best for you. I can't go to Coach and tell him this is a good idea." #The Doc
            
                ***** "Fine, just don't sign me off completely. Let me talk to the gaffer, and make that decision with him."
                
                "You've passed the concussion protocols so I can't stop you from playing, but I'll be giving Coach my opinion. The rest is down to you two." #The Doc
                
                -> Strong_TM_Buffs
    
    ** "I've had far worse Doc, those medics were being too cautious, I could've kept playing."
    
    "Listen, you can't take that mindset Sam, concussions are serious business. It was a hard knock and I know you're still suffering some of the effects." #The Doc
    
        *** "Minor symptoms, a few small headaches and nothing more. I'll pop a few paracetamol in the morning and then run out with the team as planned."
        
        "A couple of pills might help you feel up to being out there but you take another bad tackle and your career could be over Sam." #The Doc
        
            **** "I'm at the back end of my career already Doc. I want to go down fighting and I intend to. I will be walking out onto that pitch tomorrow."
            
            "You've passed the protocols Sam, so I can't stop you, but I intend on telling Coach what a bad idea this is." #The Doc
            
                ***** "You do that Doc, if you feel you need to. I do respect your opinion, but I have to do this. I hope you can understand that."
                
                "I understand you're drive to play Sam but I can't condone it. I'll simply wish you good luck." #The Doc
                
                -> Strong_Ego_Buffs

        *** "I know myself well Doc, whatever effects I might still be having, it's nothing I haven't dealt with before. I'm not gonna let this keep me out the final."
        
        "I'm the doctor around here Sam, and I don't care how tough you think you are. Another hit like that when you're not fully healed will have serious effects." #The Doc
        
            **** "I guess I'll have to avoid getting hit then Doc because you arent going to prevent me from playing. I've passed the protocols, you can't stop me."
            
            "You're right I can't. All I can do is give my recommendation to Coach, the rest is up to you two to figure out. #The Doc
            
                ***** "I'll go figure it out with him then. This is my time, the gaffer will be able to understand that."
                
                "I only hope he sees sense so that your time isn't cut short Sam." #The Doc

                -> Full_Ego_Buffs
                
                

== Full_Ego_Buffs ==
* ["Right. Laters Doc."]
    Ego Increased by 60
    Team Morale increased by 40
    ~ setEgo(60)
    ~ setTeamMorale(40)
    -> Continue


== Strong_Ego_Buffs ==
* ["I won't need it Doc, but thanks all the same."]
    Ego Increased by 55
    Team Morale increased by 45
    ~ setEgo(55)
    ~ setTeamMorale(45)
    -> Continue


== Balanced_Buffs ==
* ["Appreciate it Boss, see you."]
    Ego Increased by 50. <>
    Team Morale increased by 50.
    ~ setEgo(50)
    ~ setTeamMorale(50)
    -> Continue


== Strong_TM_Buffs ==
* ["I respect that Doc, see you."]
    Ego increased by 45
    Team Morale increased by 55
    ~ setEgo(45)
    ~ setTeamMorale(55)
    -> Continue


== Full_TM_Buffs == 
* ["See you Doc."]
    Ego increased by 40 <>
    Team Morale increased by 60
    ~ setEgo(40)
    ~ setTeamMorale(60)
    -> Continue


== Continue ==
    * Leave the Room
        -> End_Story


== End_Story ==
    -> END
    
    
    
== function setEgo(buff) ==
~ Ego = Ego + buff 


== function setTeamMorale(buff) ==
~ TeamMorale = TeamMorale + buff

