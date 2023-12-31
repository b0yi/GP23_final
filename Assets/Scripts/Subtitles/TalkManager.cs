using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public int currentSubtitle = 0;
    public float charPerSec = 20f;
    public float delayTime = 1.3f;

    [DisplayOnly] public List<bool> treeBools = new List<bool>() {
        false, // tree 0
        false, // tree 1
        false, // tree 2
        false  // tree 3
    };
    public bool brokenPlanetBool = false;
    public bool sunBool = false;
    public bool dragonCrystalBool = false;

    public List<List<string>> subtitles = new List<List<string>>() {
        // stele - 0
        new List<string>() {
            "<i>This is a bleak and desolate planet.</i>",
            "<i>However, this equiment indicates that there one others of your kind in nearby orbits.</i>",
            "<i>......Two Venusians.</i>",
            "<i>For a civilization that once dominated the solar system, you find this highly ironic.</i>",
        },
        // cat - 1
        new List<string>() {
            "Cat-111: Jesus Christ...... a true, living Venusian!",
            "Cat-111: Young Messenger, you have truly astonished me.",
            "Cat-111: Anyway, thank you for playing with my kitten",
            "<i>This cat is a bona fide Venusian. That is weird.</i>",
            @"<i>With meeting a countryman, some memory stir......
a memory concerning...... the day of defeat.</i>",
            "Cat-111: The defeat of Venus......",
            "Cat-111: It was a century ago; your mourning is belated.",
            "<i>It doesn't sound so hard to accept.</i>",
            "<i>Your only thought is to go home...... after a century of separation.</i>",
            "Cat-111: Are you serious?",
            "Cat-111: It's not easy to leave.",
            "Cat-111: The event horizon of the black hole,it is a big problem.",
            "Cat-111: I mean, I don't hate this place.",
            "Cat-111: Look at those cute kittens on my planet.",
            "Cat-111: Anyway, I can't help you, even if I wanted to.",
            "Cat-111: By the way, there's a mysterious star in orbit around here.",
            "Cat-111: A planet composed entirely of liquid water, and it’s so far away from the sun...... Where does the energy come from?",
            "<i>The Physics? Or a higher rule behind?</i>",
        },
        // fish - 2
        new List<string>() {
            "CatFish: A deep, resonating sound.",
            "<i>You have never seen such a creature before.</i>",
            "<i>That’s the reason why this planet doesn't freeze.</i>",
            "<i>The power of this entity sustains an entire planet.</i>",
            "CatFish: The gaze from the abyss.",
            "<i>Your brain...... your sanity is under invasion.</i>",
            "<i>Fortunately,it seems to lack hostility.</i>",
            "<i>Feeling discomfort from a voice resonating in the mind.</i>",
            "CatFish: Human being......",
            "CatFish: The blackhole...... the cage woven by gravity. We are all imprisoned within it.",
            "<i>Even a powerful creature like this is unable to escape.</i>",
            "<i>You've lost confidence.</i>",
            "CatFish: ...... A being of far greater power...... hiding within the maze.",
            "CatFish: It is your way home.",
        },
        // mazeBeforeFall - 3
        new List<string>() {
            "<i>Who created this structure?</i>",
            "<i>You feel the extra energy fluid underground.</i>"
        },
        // mazeAfterFall - 4
        new List<string>() {
            "<i>This seems to be man-made...... or other-made?</i>",
        },
        // dragon - 5
        new List<string>() {
            "<i>This place. It’s not a planet.</i>",
            "<i>You can not believe it.</i>",
            "<i>After millennium......</i>",
            "<i>A great monster, the Venusian warrior, lies dormant here.</i>",
            "<i>Probably the only remain.</i>",
        },
        // touchCrystal - 6
        new List<string>() {
            "<i>You don't know if this great monster will heed your words.</i>",
            "<i>But you believe he will.</i>",
            "<i>He is the glory of the past Venusian empire.</i>",
            "<i>And now, a Venusian is calling for help.</i>",
            "<i>You say:</i>",
            "M-107 (You): Wake up, old soldier.",
            "M-107 (You): Please, take me home.",
        },
        // yermengard - 7
        // new List<string>() {
        //     "Yermengard: Who disturbed my peace will pay.",
        //     "M-107 (You): Run!"
        // },
        // maybeDie2Times - 8
        // new List<string>() {
        //     "M-107 (You): Or do I use this giant with the black hole?"
        // },
    };

    public List<List<string>> treeSubtitles = new List<List<string>>() {
        // tree 0
        new List<string>() {
            "<i>This is the Energy Extraction tree planted by the Venusians to obtain energy called ‘extrenergy fluid’.</i>",
        },
        // tree 1
        new List<string>() {
            "<i>The life force, extrenergy fluid, is fading.</i>",
        },
        // tree 2
        new List<string>() {
            "<i>Trees have extracted extrenergy fluid for millenniums...... this planet is dying.</i>",
        },
        // tree 3
        new List<string>() {
            "<i>This planet is in its final days. Your awakening is a miracle.</i>",
        },
        // tree in maze
        new List<string>() {
            "<i>There were your fellow beings here.</i>",
        },
    };

    public List<string> brokenPlanetSubtitle = new List<string>() {
        "<i>Lost the extraenergy fluid, the planet collapsed.</i>",
        "<i>It won't be long before all the planets here meet the same fate.</i>",
    };

    public List<string> sunSubtitle = new List<string>() {
        "A burning planet.",
        "Hope Venus will not be.",
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
