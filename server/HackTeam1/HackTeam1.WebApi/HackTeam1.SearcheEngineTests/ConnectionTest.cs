using System;
using System.Linq;
using HackTeam1.Entities;
using HackTeam1.SearchEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackTeam1.SearcheEngineTests
{
    [TestClass]
    public class ConnectionTest
    {
        private string textSample = @"1Thefrustratedarchitect
The IT industry is either taking giant leaps ahead or it’s in deep turmoil. On the one hand we’re pushing forward, reinventing the way that we build software and striving for craftsmanship at every turn. On the other though, we’re continually forgetting the good of the past and software teams are still screwing up on an alarmingly regular basis. Software architecture plays a pivotal role in the delivery of successful software yet it’s frustratinglyneglected bymany teams. Whether performed byoneperson or sharedamongstthe team, the software architecture role exists on even the most agile of teams yet the balance of up front and evolutionary thinking often reflects aspiration rather than reality.
Softwarearchitecturehasabadreputation
I tend to get one of two responses if I introduce myself as a software architect. Either people think it’s really cool and want to know more or they give me a look that says “I want to talk to somebody that actually writes software, not a box drawing hand-waver”. The software architecture role has a bad reputation within the IT industry and it’s not hard to see where this has come from. The thought of “software architecture” conjures up visions of ivory tower architects doing big design up front and handing over huge UML models or 200 page Microsoft Word documents to an unsuspecting development team as if they were the second leg of a relay race. And that’s assumingthearchitectactuallygetsinvolvedindesigningsoftwareofcourse.Manypeopleseem to think that creating a Microsoft PowerPoint presentation with a slide containing a big box labelled “Enterprise Service Bus” is software design. Oh, and we mustn’t forget the obligatory narrative about “ROI” and “TCO” that will undoubtedly accompany the presentation. Many organisations have an interesting take on software development as a whole too. For example, they’ve seen the potential cost savings that offshoring can bring and therefore see the coding part of the software development process as being something of a commodity. The result tends to be that local developers are pushed into the “higher value” software architecture jobs with an expectation that all coding will be undertaken by somebody else. In many cases this only exaggerates the disconnect between software design and software development, with people often being pushed into a role that they are not prepared for. These same organisations tend to see software architecture as a rank rather than a role.
Agileaspirations
Agile might be over ten years old, but it’s still the shiny new kid in town and many software teams have aspirations of “becoming agile”. Agile undoubtedly has a number of benefits but it isn’t necessarily the silver bullet that everybody wants you to believe it is. As with everything
The frustrated architect 3
in the IT industry, there’s a large degree of evangelism and hype surrounding it. Start a new software project today and it’s all about self-organising teams, automated acceptance testing, continuous delivery, retrospectives, Kanban boards, emergent design and a whole host of other buzzwords that you’ve probably heard of. This is fantastic but often teams tend to throw the baby out with the bath water in their haste to adopt all of these cool practices. “Non-functional requirements” not sounding cool isn’t a reason to neglect them. What’s all this old-fashioned software architecture stuff anyway? Many software teams seem to think that they don’t need software architects, throwing around terms like “self-organising team”, “YAGNI”, “evolutionary architecture” and “last responsible moment” instead. If they do needanarchitect,they’llprobablybeonthelookoutforan“agilearchitect”.I’mnotentirelysure what this term actually means, but I assume that it has something to do with using post-it notes instead of UML or doing TDD instead of drawing pictures. That is, assuming they get past the notion of only using a very high level system metaphor and don’t use “emergent design” as an excuse for foolishly hoping for the best.
Soyouthinkyou’reanarchitect?
It also turns out there are a number of people in the industry claiming to be software architects whereas they’re actually doing something else entirely. I can forgive people misrepresenting themselves as an “Enterprise Architect” when they’re actually doing hands-on software architecture within a large enterprise. The terminology in our industry is often confusing after all. But what about those people that tend to exaggerate the truth about the role they play on software teams? Such irresponsible architects are usually tasked with being the technical leader yet fail to cover the basics. I’ve seen public facing websites go into a user acceptance testing environment with a number of basic security problems, a lack of basic performance testing, basic functionality problems, broken hyperlinks and a complete lack of documentation. And that was just my external view of the software, who knows what the code looked like. If you’re undertaking the software architecture role and you’re delivering stuff like this, you’re doing it wrong. This isn’t software architecture, it’s also foolishly hoping for the best.
Fromfrustrationandbeyond
Admittedly not all software teams are like this but what I’ve presented here isn’t a “straw man” either. Unfortunately many organisations do actually work this way so the reputation that software architecture has shouldn’t come as any surprise. If we really do want to succeed as an industry, we need to get over our fascination with shiny newthingsandstartingaskingsomequestions.Doesagileneedarchitectureordoesarchitecture actually need agile? Have we forgotten more about good software design than we’ve learnt in recent years? Is foolishly hoping for the best sufficient for the demanding software systems we’re building today? Does any of this matter if we’re not fostering the software architects of tomorrow? How do we move from frustration to serenity? Read on to find out…
IIWhatissoftwarearchitecture?
2Whatisarchitecture?
The word “architecture” means many different things to many different people and there are many different definitions floating around the Internet. I’ve asked hundreds of people over the pastfewyearswhat“architecture”meanstothemandasummaryoftheiranswersisasfollows. These are in no particular order…
• Modules, connections, dependencies and interfaces • The big picture • The things that are expensive to change • The things that are difficult to change • Design with the bigger picture in mind • Interfaces rather than implementation • Aesthetics (e.g. as an art form, clean code) • A conceptual model • Satisfying non-functional requirements/quality attributes • Everything has an “architecture” • Ability to communicate (abstractions, language, vocabulary) • A plan • A degree of rigidity and solidity • A blueprint • Systems, subsystems, interactions and interfaces • Governance • The outcome of strategic decisions • Necessary constraints • Structure (components and interactions) • Technical direction • Strategy and vision • Building blocks • The process to achieve a goal • Standards and guidelines • The system as a whole • Tools and methods • A path from requirements to the end-product • Guiding principles • Technical leadership • The relationship between the elements that make up the product • Awareness of environmental constraints and restrictions • Foundations
What is architecture? 6
• An abstract view • The decomposition of the problem into smaller implementable elements • The skeleton/backbone of the product
No wonder it’s hard to find a single definition! Thankfully there are two common themes here … architecture as a noun and architecture as a verb, with both being applicable regardless of whether we’re talking about constructing a physical building or a software system.
Asanoun
As a noun then, architecture can be summarised as being about structure and is about the decomposition of a product into a collection of components and interactions. This needs to take into account the whole of the product, including the foundations and infrastructure services that deal with cross-cutting concerns such as power/water/air conditioning (for a building) or security/configuration/error handling (for a piece of software).
Asaverb
As a verb, architecture (i.e. the process, architecting) is about understanding what you need to build, creating a vision for building it and making design decisions. Crucially, it’s also about communicating that vision so that everybody involved with the construction of the product understands the vision and is able to contribute in a positive way to its success. Put simply, the process of architecting is about introducing technical leadership.
3Issoftwarearchitecture important?
Softwarearchitecturethen,isitimportant?Theagileandsoftwarecraftsmanshipmovementsare helpingtopushupthequalityofthesoftwaresystemsthatwebuild,whichisexcellent.Together they are helping us to write better software that better meets the needs of the business while carefully managing time and budgetary constraints. But there’s still more we can do because evenasmallamountofsoftwarearchitecturecanhelppreventmanyoftheproblemsthatprojects face. Successful software projects aren’t just about good code and sometimes you need to step away from the IDE for a few moments to see the bigger picture.
Alackofsoftwarearchitecturecausesproblems
Sincesoftwarearchitectureisaboutstructureandvision,youcouldsaythatitexistsanyway.And I agree, it does. Having said that, it’s easy to see how not thinking about software architecture (and the “bigger picture”) can lead to a number of common problems that software teams face on a regular basis. Ask yourself the following questions:
• Does your software system have a well defined structure? • Is everybody on the team implementing features in a consistent way? • Is there a consistent level of quality across the codebase? • Is there a shared vision for how the software will be built across the team? • Does everybody on the team have the necessary amount of technical guidance? • Is there an appropriate amount of technical leadership?
It is possible to successfully deliver a software project by answering “no” to some of these questions,butitdoesrequireaverygoodteamandalotofluck.Ifnobodythinksaboutsoftware architecture, the end result is something that typically looks like a big ball of mud. Sure, it has a structure but it’s not one that you’d want to work with! Other side effects could include the software system being too slow, insecure, fragile, unstable, hard to deploy, hard to maintain, hard to change, hard to extend, etc. I’m sure you’ve never seen or worked on software projects like this, right? No, me neither. ;-) Since software architecture is inherent in every software project and system, why don’t we simply acknowledge and place some focus on it?
Thebenefitsofsoftwarearchitecture
What benefits can “software architecture” provide then? In summary:
Is software architecture important? 8
• A clear vision and roadmap for the team to follow, regardless of whether that vision is owned by a single person or collectively by the whole team. • Technical leadership and better coordination. • A stimulus to talk to people in order to answer questions relating to significant decisions, non-functional requirements, constraints and other cross-cutting concerns. • A framework for identifying and mitigating risk. • Consistency of approach and standards, leading to a well structured codebase. • A set of firm foundations for the rest of the project. • A structure with which to communicate the solution at different levels of abstraction to different audiences.
Doeseverysoftwareprojectneedsoftware architecture?
Rather than use the typical consulting answer of “it depends”, I’m instead going to say that the answerisundoubtedly“yes”,withthecaveatthateverysoftwareprojectshouldlookatanumber of factors in order to assess how much software architecture is necessary. These include the size of the project, the complexity of the project, the size of the team and the experience of the team. The answer to how much is “just enough” will be explored throughout the rest of this book.
4Questions
1. Do you know what “architecture” is all about? Does the rest of your team? What about the rest of your organisation? 2. There are a number of different types of architecture within the IT domain. What do they all have in common? 3. Do you and your team have a standard definition of what “software architecture” means? Couldyoueasilyexplainittonewmembersoftheteam?Isthisdefinitioncommonacross your organisation? 4. Can you make a list of the architectural decisions on your current software project? Is it obvious why they were deemed as significant? 5. If you step back from your IDE, what sort of things are included in your big picture? 6. What does the technical career path look like in your organisation? Is enterprise architecture the right path for you? 7. Is software architecture important? Why and what are the benefits? Is there enough software architecture on your software project? Is there too much?
IIIThesoftwarearchitecturerole
5Softwaredevelopmentisnota relaysport
Software teams that are smaller and/or agile tend to be staffed with people that are generalising specialists; people that have a core specialism along with more general knowledge and experience. In an ideal world, these cross-discipline team members would work together to run and deliver a software project, undertaking everything from requirements capture and architecture through to coding and deployment. Although many software teams strive to be self-organising, in the real world they tend to be larger, more chaotic and staffed only with specialists. These teams, therefore, tend to need and have somebody in the technical leadership role.
“SolutionArchitects”
There are a lot of people out there, particularly in larger organisations, calling themselves “solutionarchitects”or“technicalarchitects”whodesignsoftwareanddocumenttheirsolutions before throwing them over the wall to a separate development team. With the solution “done”, thearchitectwillthenmoveontothedothesamesomewhereelse,oftennoteventakingacursory glimpse at how the development team is progressing. When you throw “not invented here” syndrome into the mix, there’s often a tendency for that receiving team to not take ownership of the architecture and the “architecture” initially created becomes detached from reality. I’vemetanumberofsucharchitectsinthepastandoneparticularinterviewIheldepitomisesthis approach to software development. After the usual “tell me about your role and recent projects” conversation, it became clear to me that this particular architect (who worked for one of the large “blue chip” consulting firms) would create and document a software architecture for a project before moving on elsewhere to repeat the process. After telling me that he had little or no involvement in the project after he handed over the “solution”, I asked him how he knew that his software architecture would work. Puzzled by this question, he eventually made the statement that this was “an implementation detail”. Essentially, his view was that his software architecture was correct and it was the development team’s problem if they couldn’t get it to work for any reason. That’s outrageous!
Somebodyneedstoownthebigpicture
The software architecture role is that of a generalising specialist and different to your typical softwaredeveloper. It’s certainly about steering the ship at the start of a softwareproject, which includes things like managing the non-functional requirements and putting together a software designthatissensitivetothecontextandenvironmentalfactors.Butit’salsoaboutcontinuously steering the ship because your chosen path might need some adjustment en-route. Agile has taught us that we don’t necessary have all of the information up front.
Software development is not a relay sport 12
A successful software project requires the initial vision to be understood, communicated and potentiallyevolvedthroughouttheentiretyofthesoftwaredevelopmentlifecycle.Forthisreason alone, it doesn’t make sense for one person to create that vision and for another team to (try to) deliverit.Whenthisdoeshappen,thesetofdesignartefactsisessentiallyabatonthatgetspassed betweenthearchitectandthedevelopmentteam.Thisisinefficient,ineffectiveandtheexchange ofadocumentmeansthatalotofthedecisionmakingcontextassociatedwithcreatingthevision is also lost. Let’s hope that the development team never needs to ask any questions about the design or its intent!
Software development is not a relay sport
This problem goes away with truly self-organising teams, but most teams haven’t yet reached thislevelofmaturity.Therefore,somebodyneedstotakeownershipofthebigpicturethroughout the project and they also need to take responsibility for ensuring that it’s delivered successfully. If somebody has designed the software, why shouldn’t they own and take responsibility for it throughout the rest of the project? Software development is not a relay sport and successful delivery is not an “implementation detail”.
6Wherearethesoftwarearchitects oftomorrow?
Agile and software craftsmanship are two great examples of how we’re striving to improve and push the software industry forward. We spend a lot of time talking about writing code, testing, tools, technologies and the all of the associated processes. And that makes a lot of sense becausetheend-goalhereisdeliveringbenefittopeoplethroughsoftware,andworkingsoftware is key. But we shouldn’t forget that there are some other aspects of the software development process that few people genuinely have experience with. Think about how you would answer the following questions.
1. When did you last code? • Earlier today, I’m a software developer so it’s part of the job. 2. When did you last refactor? • I’m always looking to make my code the best I can, and that includes refactoring if necessary. Extract method, rename, pull up, push down … I know all that stuff. 3. When did you last test your code? • We test continuously by writing automated tests either before, during or after we writeanyproductioncode.Weuseamixofunit,integrationandacceptancetesting. 4. When did you last design something? • Idoitallthetime,it’sapartofmyjobasasoftwaredeveloper.Ineedtothinkabout howsomethingwillworkbeforecodingit,whetherthat’sbysketchingoutadiagram or using TDD. 5. When did you last design a software system from scratch? I mean, take a set of vague requirements and genuinely create something from nothing? • Well,there’snotmuchopportunityonmycurrentproject,butIhaveanopensource project that I work on in my spare time. It’s only for my own use though. 6. When did you last design a software system from scratch that would be implemented by a team of people. • Umm, that’s not something I get to do.
Let’sfaceit,mostsoftwaredevelopersdon’tgettotakeablanksheetofpaperanddesignsoftware fromscratchallthatfrequently,regardlessofwhetherthatdesignisupfrontorevolutionaryand whether it’s a solo or collaborative exercise. We’relosingourtechnicalmentors
The sad thing about our industry is that many developers are being forced into non-technical management positions in order to progress their careers up the corporate ladder. Ironically, it’s often the best and most senior technical people that are being forced away, robbing software teamsoftheirmostvaluedtechnicalleads,architectsandmentors.Fillingthisgaptomorroware the developers of today.
Where are the software architects of tomorrow? 14 Softwareteamsneeddowntime
Many teams have already lost their most senior technical people, adding more work to the remainder of the team that are already struggling to balance all of the usual project constraints along with the pressures introduced by whatever is currently fashionable in the IT industry … agile, craftsmanship, cloud, rich Internet UIs, functional programming, etc. Many teams appreciate that they should be striving for improvement,but lack the time or the incentiveto do it. ";

        private ElasticSearchEngine elastic;


        private Document ObjectNr1 
        {
          get {
                return new Document()
                {
                    Category = "MyCategory",
                    MimeType = "docx",
                    Title = "qazwsxedc",
                    Text = this.textSample,
                    OcrFileName = "C:/departe",
                    OriginalFileName = "lisp",
                    CreatedDate = DateTime.Now,
                    IndexedDate = DateTime.Now
                };
            }  
        }

        private Document ObjectNr2
        {
            get
            {
                return new Document
                {
                    Category = "Invoice",
                    MimeType = "pdf",
                    Title = "AgileFreaks Invoice",
                    OcrFileName = "Lisp",
                    OriginalFileName = "nuiswq",
                    Text = this.textSample,
                    CreatedDate = DateTime.Now,
                    IndexedDate = DateTime.Now
                };
            }
        }

        [TestInitialize]
        public void Initilize()
        {
            elastic = new ElasticSearchEngine("document");
        }

        [TestMethod]
        public void GetDocumensByTitleTest()
        {
            elastic.Index(this.ObjectNr1);

            var myData = elastic.Search("qazwsxe initial vision to be understood");

            Assert.AreEqual("MyCategory", myData.First().Category);
        }

        [TestMethod]
        public void TestBoosting()
        {
            elastic.Index(ObjectNr1);
            elastic.Index(ObjectNr2);

             var myData = elastic.Search("assuming AgileFreaks");
            
            Assert.IsTrue(myData.Count() == 2);
            Assert.AreEqual(ObjectNr2.Title, myData.First().Title);
        }


        [TestMethod]
        public void TestGetBy()
        {
            var doc = new Document
            {
                OriginalFileName = "powerpuff",
                Title = "ma duc la piata",
                OcrFileName = "nomNom",
                Text = "my favourite text",
                CreatedDate = DateTime.Now,
                IndexedDate = DateTime.Now,
                MimeType = "tiff",
                Category = "Nebunie",
            };

            elastic.Index(doc);

            var document = this.elastic.GetBy(doc.OriginalFileName);

            Assert.AreEqual(doc.Title, document.Title);
        }

        [TestMethod]
        public void testShit()
        {
            var aaa = this.elastic.Search("certificat de garantie");
            var bb = 5;
        }
    }
}