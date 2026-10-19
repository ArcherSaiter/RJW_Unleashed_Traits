# RJW_Traits

RJW themed traits are there! Sadists, truly insatiable, submissive and pliable are now at your disposal!

## Featuring:
* Tomboy - pretty, better at social & sexual (sexperience), adjustments to vulnerability, sex frequency and break threshold. `rare`
* Femboy - pretty, better at social & sexual (sexperience), adjustments to vulnerability, sex frequency and break threshold. `rare`
* Bimbo/Himbo - Dumb, pretty, good at fucking `very rare` (now with 'himbo' label for males)
* Incel/Femcel - Bad at social, mentally unstable `rare`
* Sexually_Numb - no mood from any sex, no need, doesn't get broken, (they still do lewd stuff occasionally) `rare`
* Animal_Mind - barely allowed to work, no humanlike needs, `very rare`
* Insatiable - wants to fuck. A LOT. But still has preferences, opposed to numphs, `uncommon`
* Submissive (Meek) - put up with rape, but can still be broken, `uncommon`
* Rapetoy - very attractive, super vulnerable, `uncommon`
* Pliable - attractive, very vulnerable, `common`
* Playful_Sadist - Bloodlust + a bit of rapist, `common`
* Brutal_Sadist - Bloodlusty and rapist, mixed almost equally, `uncommon`
* Degrader - cruelly insults whoever they secretly desire instead of casual chat, `rare`
* Degradee - insults and humiliation delight them, they grow fond of the insulter, `rare`
* Homewrecker - unbothered by relationships, far more likely and successful at seducing the taken, `rare`
* Sexual predator - the more pent-up, the sharper their senses and the closer to a rape break, `rare`

#### Disease addon (RJW-Genes):
* Bimbofier
* Femboifier
* Tomboifier
* Rapetoifyer (with masochism)
* Infective Insatiability

## Technical Details:

Femboy
* commonality = 0.1, commonalityFemale = 0.0
* stat offsets: Beauty +1, Vulnerability +20%, SexFrequency +20%, MentalBreakThreshold +5%
* skill gains: Social +2, Sex (sexperience) +2

Tomboy
* commonality = 0.0, commonalityFemale = 0.1
* stat offsets: Beauty +1, Vulnerability -20%, SexFrequency +20%, MentalBreakThreshold -5%
* skill gains: Social +2, Sex (sexperience) +2

Bimbo
* forced passions: Sex (sexperience), Social
* stat offsets: Beauty +2, GlobalLearningFactor -75%, SocialImpact -50%, Vulnerability +75%, SexFrequency +50%
* skill gains: Intellectual -8, Social +3, Sex (sexperience) +8

Incel/Femcel
* stat offsets: SocialImpact -25%, Vulnerability +15%, SexFrequency -25%, MentalBreakThreshold +10%
* May have randomMentalState RandomRape if mood below 35
* skill gains: Social -3, Sex (sexperience) -2

Playful_Sadist
* x2 social Fight Chance Factor
* 0.5 commonality (same as masochist)
* Adds Morbid Meditation Focus Type
* +10% sex Frequency
* May have RandomRape Mental State (half as frequent compared to rapist)
* Always capable of violence
* Conflicts with Brutal_Sadist
* Same thought filter as bloodlust

Brutal_Sadist 
* x5 social Fight Chance Factor
* 0.1 commonality
* Adds Morbid Meditation Focus Type
* +25% sex Frequency
* May have RandomRape Mental State (more than 2 times as frequent compared to rapist, 5 times as frequent compared to Playful_Sadist)
* Always capable of violence
* Conflicts with Playful_Sadist and Kind
* Same thought filter as bloodlust

Pliable
* +1 beauty
* +200% vulnerability
* 0.5 commonality (same as masochist)

Rapetoy
* +2 beauty
* +500% vulnerability
* 0.1 commonality

Submissive
* +50% vulnerability
* 0.1 commonality
* -5% Mental Break Threshold
* No negative thoughts from rape, works properly with masochist (masochist thoughts override)

Insatiable
* x5 sex need decay
* +10% vulnerability
* 0.05 commonality
* Adds Sex Meditation Focus Type

Animal_Mind
* 0.01 commonality
* Can't do: ManualSkilled, Cooking, Social, Caring, Shooting, Constructing, PlantWork, Crafting, Artistic, Intellectual
* -90% psy sensitivity
* -15% Mental Break Threshold
* Does not need: Comfort, Joy, Beauty, Indoors

Sexually_Numb
* -10% vulnerability
* -10% Mental Break Threshold
* -100% psy sensitivity
* Does not need: Sex
* No sex-related thoughts and sex-change thoughts (at all)

Degrader
* 0.1 commonality
* +50% Social Impact
* Skips casual chat to Insult the non-hostile humanlike pawn they are most sexually attracted to
* Up to 60% chance per roll, only while sex need is below 0.5 (emptier = more likely)
* Conflicts with Kind

Degradee
* 0.1 commonality
* +15% vulnerability, -5% Mental Break Threshold
* Being insulted swaps the vanilla Insulted thought for a positive one: +10 opinion of the insulter (20 days, up to 300 stacks / 10 per same pawn, x0.9 per extra stack) plus a +5 "humiliated" mood memory (2 days, 10 stacks, x0.9)

Homewrecker
* 0.1 commonality
* +25% Social Impact, +25% sex Frequency
* skill gains: Social +2, Sex +2
* Ignores the homewrecking attraction penalty - partnered pawns are just as attractive to them
* Romance attempts against partnered pawns: x2.5 interaction weight and x2 + 0.1 success chance (capped at 100%)
* Nullifies the RebuffedMyRomanceAttempt / RebuffedMyRomanceAttemptMood thoughts
* Conflicts with Kind

Sexual predator
* 0.1 commonality
* -10% vulnerability, +50% sex Frequency
* skill gains: Melee +3, Sex -1
* May have RandomRape Mental State
* Grants the RJW_SexualPredator_Instinct hediff, its severity is how pent-up they are, each stage scales up Sight, Hearing, Moving, Manipulation, Talking and cuts global work speed
* Conflicts with Kind
