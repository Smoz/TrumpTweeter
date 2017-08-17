-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 17, 2017 at 10:45 PM
-- Server version: 10.1.21-MariaDB
-- PHP Version: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `trumptweeterbot`
--

-- --------------------------------------------------------

--
-- Table structure for table `imageurls`
--

CREATE TABLE `imageurls` (
  `post_title` text CHARACTER SET utf8mb4 COLLATE utf8mb4_bin,
  `image_url` text CHARACTER SET utf8mb4 COLLATE utf8mb4_bin,
  `post_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `imageurls`
--

INSERT INTO `imageurls` (`post_title`, `image_url`, `post_date`) VALUES
('test title', 'test url', '0000-00-00 00:00:00'),
('Shell we start a petition to pardon this hero?', 'https://i.redd.it/hu0qqrxx4cgz.gif', '0000-00-00 00:00:00'),
('Religion of Peace Strikes Again!!!', 'https://i.redd.it/8mg20p5v4cgz.png', '0000-00-00 00:00:00'),
('Because Jesus was too based to wear a pussy hat, and would never hide his face behind a bandana to sneak-assault people with a bike lock.', 'http://i.magaimg.net/img/16qg.jpg', '0000-00-00 00:00:00'),
('Reset the counter boys', 'https://i.redd.it/p5ivzhl36cgz.png', '0000-00-00 00:00:00'),
('Delivering on her promise', 'https://i.redd.it/ouuw44c06cgz.jpg', '0000-00-00 00:00:00'),
('Is Killery the grand master of the Alt-Left?', 'https://i.redd.it/q3843aa06cgz.jpg', '0000-00-00 00:00:00'),
('The Religion Of Peace (Muslims) strike again! Liberals (Libtards/Alt-Left) everywhere right now: B-B-B-B-BUT MUH WHITE NATIONALISTS!!!!!', 'https://i.redd.it/b3o0s9d95cgz.jpg', '0000-00-00 00:00:00'),
('Well know the #FakeNews epidemic is over and that the Deep State has lost when NASA &amp; MSM finally announce that this hunk of aluminum foil never landed on and took off from the moon. Then President Trump will be the leader that ACTUALLY puts Americans on the moon. #MAGA', 'http://i.magaimg.net/img/16qe.jpg', '0000-00-00 00:00:00'),
('Because Jesus was too based to wear a pussy hat, and would never hide his face behind a bandana to sneak-assault people with a bike lock.', 'http://i.magaimg.net/img/16qg.jpg', '0000-00-00 00:00:00'),
('Made the mistake of signing up for Alt Left news alerts...wew!', 'https://i.redd.it/2750id4j7cgz.jpg', '0000-00-00 00:00:00'),
('Barcelona Terrorist Identified - Go Ahead and Ask?', 'https://i.redd.it/i7v0qr897cgz.jpg', '0000-00-00 00:00:00'),
('This is relevant', 'https://i.redd.it/d6ohvswa7cgz.jpg', '0000-00-00 00:00:00'),
('\"Hello I have a reservation for a van rental.\"', 'https://i.redd.it/cfvhrfu57cgz.jpg', '0000-00-00 00:00:00'),
('Im sure Sadiq Khan will receive exactly as much criticism as Trump for failing to name the ideology behind a terrorist attack (he wont)', 'https://i.redd.it/1aoi33iy6cgz.png', '0000-00-00 00:00:00'),
('Response from Chinese government after protesters destroyed statue', 'https://i.redd.it/nc309sox6cgz.jpg', '0000-00-00 00:00:00'),
('THE PYRAMIDS WERE BUILT BY SLAVES - TIME TO BRING EM DOWN BOYS! THE PYRAMIDS ARE RACIST!!! REEEEEEEEEE', 'https://i.redd.it/8n10i4p0dcgz.jpg', '0000-00-00 00:00:00'),
('\"Thanks for setting up all that violence and media coverage to distract people from my vote to destroy the healthcare system.\" \"I got you fam.\"', 'https://i.redd.it/5qb8j2lxccgz.jpg', '0000-00-00 00:00:00'),
('Every time you press this key, a piece of history is erased!', 'http://i.magaimg.net/img/16m2.png', '0000-00-00 00:00:00'),
('ALT-LEFT', 'http://i.magaimg.net/img/16r7.jpg', '0000-00-00 00:00:00'),
('Currently without political affiliation, but thinking of supporting Hillary, Barrack, McCain, and other Democrats. Talk me out of it.', 'http://i.magaimg.net/img/16r6.jpg', '0000-00-00 00:00:00'),
('Incoming #PrayforBarcelona Reset the Counter Boys', 'https://i.redd.it/ivdiejzhccgz.jpg', '0000-00-00 00:00:00'),
('Handy Reference Chart for Barcelona and Charlottesville', 'https://i.redd.it/d17oup9lccgz.png', '0000-00-00 00:00:00'),
('The left is actually unbelievable!', 'http://i.imgur.com/HbDoxKt.png', '0000-00-00 00:00:00'),
('General Black Jack Pershing: Certified Badass, Destroyer of Evil', 'https://i.redd.it/ewzl2uyfgcgz.jpg', '0000-00-00 00:00:00'),
('\"But Byrd disavowed the KKK years ago!\" they say... So did David Duke. Duke was ostracized by the GOP anyway, Byrd was lionized by the Dems. See the difference?', 'https://i.redd.it/2tksgnkhgcgz.jpg', '0000-00-00 00:00:00'),
('Long time lurker first time poster. Am I doing this right?', 'https://i.redd.it/gu0qw1mjgcgz.jpg', '0000-00-00 00:00:00'),
('Milo looks like Hayden Christensen!', 'https://i.redd.it/kqbkac9igcgz.jpg', '0000-00-00 00:00:00'),
('THATS MY PRESIDENT!', 'https://i.redd.it/dyl4b1dhgcgz.jpg', '0000-00-00 00:00:00'),
('This is what liberals actually believe', 'https://i.redd.it/ywwijpdbgcgz.png', '0000-00-00 00:00:00'),
('Liberals are posting this like crazy. Can we use this against them with their acceptance of the religion of \"peace?\"', 'https://i.redd.it/p9wwnsodgcgz.jpg', '0000-00-00 00:00:00'),
('As if it were even possible... Here is a line of cucks waiting to make themselves even less employable by turning themselves in for toppling the statue in Durham', 'https://i.redd.it/xd2dsrsbgcgz.jpg', '0000-00-00 00:00:00'),
('Fuck this guy', 'https://i.redd.it/fndepshwjcgz.jpg', '0000-00-00 00:00:00'),
('History offers answers.', 'http://i.magaimg.net/img/16rk.png', '0000-00-00 00:00:00'),
('The folks to the right on the horses are Ferdinand and Isabella. They defeated the Moors in Spain and drove them out after a long 780 year Reconquista. They were kept out until mass migration ruined the country. You probably didnt learn this because of historical revision by the left.', 'http://i.magaimg.net/img/16rj.jpg', '0000-00-00 00:00:00'),
('A Rare positive-score Comment on /r/all', 'http://i.imgur.com/xa93YMA.png', '0000-00-00 00:00:00'),
('Sick front page right now. TIL about \"cruel Spainards\" submitted and upvoted at same time as Barcelona terror attack. These people are ridiculous.', 'https://i.redd.it/qmzauuknkcgz.jpg', '0000-00-00 00:00:00'),
('This is MEGA FUCKED UP!!!! I am just about over all this PC BS!!', 'https://i.redd.it/26csym0nlcgz.jpg', '0000-00-00 00:00:00'),
('Just doing my civic duties', 'http://i.imgur.com/LyzZBMG.jpg', '0000-00-00 00:00:00'),
('Can Someone find the co-Author of art of the deal, DELETED TWEETS attacking the kids? This guy who has been attacking Trump for years ... now his kids?', 'https://i.redd.it/yb5lohamlcgz.jpg', '0000-00-00 00:00:00'),
('EXCLUSIVE: CNN HAS IDENTIFIED THE TERRORIST', 'https://i.redd.it/srh6oegglcgz.jpg', '0000-00-00 00:00:00'),
('Fed Up With Drudge?', 'https://i.redd.it/sh9c5b9klcgz.jpg', '0000-00-00 00:00:00'),
('Trump Right Again: Left Now Advocating For Removal Of Mount Rushmore.', 'https://i.redd.it/6h8vkywglcgz.png', '0000-00-00 00:00:00'),
('Lets not jump to conclusions now.', 'https://i.redd.it/820613rhlcgz.jpg', '0000-00-00 00:00:00'),
('Meanwhile, at the top of Reddit, a \"van hits crowd\". Similar to when knifes go on stabbing sprees, or lighters commit arson.', 'https://i.redd.it/uyre2xtclcgz.jpg', '0000-00-00 00:00:00'),
('Well, if we are rewriting history to remove racism from our culture, we should start here...', 'https://i.redd.it/jbqu3sj9ncgz.jpg', '0000-00-00 00:00:00'),
('Since were getting rid of hate groups, hate speech and their symbols I guess its time to ban this and anyone that follows it.', 'https://i.redd.it/i6hzlyuzmcgz.jpg', '0000-00-00 00:00:00'),
('Trending on twitter right now. WTF How is this allowed?!', 'https://i.redd.it/3clud7zxmcgz.jpg', '0000-00-00 00:00:00'),
('Just a Democratic Congresswoman wanting to see the President Assassinated....No Bid Deal.', 'https://i.redd.it/m9ntcl8jmcgz.jpg', '0000-00-00 00:00:00'),
('The left love KJU!', 'https://i.redd.it/adr9jabiocgz.jpg', '0000-00-00 00:00:00'),
('Antifa are now posing as Nazis when the press is around to help them craft a false narrative against Trump supporters. Everyone needs to be aware of this including the MSM, even if they chose to ignore it.', 'https://i.redd.it/9h0xppobocgz.jpg', '0000-00-00 00:00:00'),
('Antifa its called fascist. Accuses their other as being a Nazi sympathizer. Whats next? Call to violence?', 'https://i.redd.it/l539oe07ocgz.png', '0000-00-00 00:00:00'),
('Will liberals disavow?', 'https://i.redd.it/4bw0tdpcocgz.jpg', '0000-00-00 00:00:00'),
('One of these journalists has exposed corruption and crimes world wide. Hes been detained at the Ecuadorian Embassy for 7 years. History will remember the name Julian Assange, not these propagandists. Enjoy the Twitter followers cucks because were Julians getting a statue', 'https://i.redd.it/k1lb6scbocgz.jpg', '0000-00-00 00:00:00'),
('With plenty of free time, Hillary moderates her own subreddit with an IRON FIST between bouts of coughing, falling unconscious, shitting herself, and scissoring younger women.', 'http://i.magaimg.net/img/16ru.png', '0000-00-00 00:00:00'),
('Ban Assault VANS', 'https://i.redd.it/k5u4mxk7ocgz.jpg', '0000-00-00 00:00:00'),
('New Tweet from the King of Spain calls out Islamic Terror: \"They are assasins, simply criminals that will continue to terrorize us. All of Spain is Barcelona. Las Ramblas will continue to be ours.\"', 'http://i.imgur.com/sAnTcO2.png', '0000-00-00 00:00:00'),
('CAN EVERYONE PLEASE JUST STOP FOR ONE MINUTE, JUST A FEW MEASLY SECONDS, AND HELP THOSE POOR SOULS. THEY NEED MORE HASHTAGS AND UPDATED PROFILE PICS. ITS THE ONLY THING WE CAN DO!', 'http://i.imgur.com/c5T3Gmz.jpg', '0000-00-00 00:00:00'),
('Reddit Victim Blaming 101: the top two posts on /r/all', 'http://i.magaimg.net/img/16rs.png', '0000-00-00 00:00:00'),
('Does she disavow?', 'http://i.magaimg.net/img/16s2.jpg', '0000-00-00 00:00:00'),
('When Blue-Checkmarked Cucks try to tell you shooting Islamic TERRORISTS with bullets dipped in pigs blood is a \"War Crime\".', 'https://i.redd.it/imp9ta0aqcgz.gif', '0000-00-00 00:00:00'),
('The best part about labeling terrorist attacks as Alt Left is that leftards respond with: \"It wasnt Alt Left! It was Muslims!\"', 'https://i.redd.it/psc2cuijqcgz.jpg', '0000-00-00 00:00:00'),
('Washington Post gets one right!', 'https://i.redd.it/llvzoyhhqcgz.png', '0000-00-00 00:00:00'),
('Best time for free promotions!!', 'https://i.redd.it/kh8jm9niqcgz.jpg', '0000-00-00 00:00:00'),
('Vice goes full reeeeeeetard over monuments.', 'https://i.redd.it/ccygrgx3qcgz.jpg', '0000-00-00 00:00:00'),
('WE LOVE YOU: President Trumps Response to Spains Islamic Terrorirst Attack', 'http://i.imgur.com/kLlIqd7.png', '0000-00-00 00:00:00'),
('USA TODAY calls the terror attack a \"runaway van\"', 'https://i.redd.it/yahvkbkaqcgz.jpg', '0000-00-00 00:00:00'),
('Been a while since Ive seen pepe on T_D; The ALT-LEFT ruins everything!', 'https://i.redd.it/3sf0fbz6qcgz.jpg', '0000-00-00 00:00:00'),
('California Bill: 1 Year in Jail for Using Wrong Transgender Pronoun', 'http://i.imgur.com/gyG6Cmp.jpg', '0000-00-00 00:00:00'),
('Hhhmmm car runs down someone at antifa rally... white supremacists and Trump are to blame. Van of peace in Barcelona... but this somehow is vehicular terrorism the MSM will forget about...', 'https://i.redd.it/ca0sg9g8qcgz.jpg', '0000-00-00 00:00:00'),
('Wolf Blitzer wonders if Barcelona van attack is copycat of Charlottesville.', 'https://i.redd.it/yudh2uelqcgz.png', '0000-00-00 00:00:00'),
('Does she disavow?', 'http://i.magaimg.net/img/16s2.jpg', '0000-00-00 00:00:00'),
('When Blue-Checkmarked Cucks try to tell you shooting Islamic TERRORISTS with bullets dipped in pigs blood is a \"War Crime\".', 'https://i.redd.it/imp9ta0aqcgz.gif', '0000-00-00 00:00:00'),
('The best part about labeling terrorist attacks as Alt Left is that leftards respond with: \"It wasnt Alt Left! It was Muslims!\"', 'https://i.redd.it/psc2cuijqcgz.jpg', '0000-00-00 00:00:00'),
('Washington Post gets one right!', 'https://i.redd.it/llvzoyhhqcgz.png', '0000-00-00 00:00:00'),
('Best time for free promotions!!', 'https://i.redd.it/kh8jm9niqcgz.jpg', '0000-00-00 00:00:00'),
('Vice goes full reeeeeeetard over monuments.', 'https://i.redd.it/ccygrgx3qcgz.jpg', '0000-00-00 00:00:00'),
('WE LOVE YOU: President Trumps Response to Spains Islamic Terrorirst Attack', 'http://i.imgur.com/kLlIqd7.png', '0000-00-00 00:00:00'),
('USA TODAY calls the terror attack a \"runaway van\"', 'https://i.redd.it/yahvkbkaqcgz.jpg', '0000-00-00 00:00:00'),
('Been a while since Ive seen pepe on T_D; The ALT-LEFT ruins everything!', 'https://i.redd.it/3sf0fbz6qcgz.jpg', '0000-00-00 00:00:00'),
('California Bill: 1 Year in Jail for Using Wrong Transgender Pronoun', 'http://i.imgur.com/gyG6Cmp.jpg', '0000-00-00 00:00:00'),
('Hhhmmm car runs down someone at antifa rally... white supremacists and Trump are to blame. Van of peace in Barcelona... but this somehow is vehicular terrorism the MSM will forget about...', 'https://i.redd.it/ca0sg9g8qcgz.jpg', '0000-00-00 00:00:00'),
('Daaaamn, Islam! Back at it again with the white vans!', 'https://i.redd.it/brldkbizqcgz.jpg', '0000-00-00 00:00:00'),
('So let me get this straight... Antifa &amp; the Alt-Left are calling Trump supporters nazi fascists, but all the while taking their orders from George Soros who actually cooperated with the Nazis during WWII and called it \"The happiest time of [his] life\"?', 'https://i.redd.it/1bs0anzjqcgz.jpg', '0000-00-00 00:00:00'),
('Daily Reminder that we have the right to Keep and Arm Bears', 'http://i.imgs.fyi/img/16s4.jpg', '0000-00-00 00:00:00'),
('Odd - why would Snopes be interested in updating the General Pershing claim on the same day President Trump tweets about it?', 'https://i.redd.it/ydgnxzmqqcgz.png', '0000-00-00 00:00:00'),
('Butt-hurt Report to show we care about all those liberal tears and complaints', 'https://i.redd.it/6kb06wdxqcgz.jpg', '0000-00-00 00:00:00'),
('Wolf Blitzer wonders if Barcelona van attack is copycat of Charlottesville.', 'https://i.redd.it/yudh2uelqcgz.png', '0000-00-00 00:00:00'),
('Does she disavow?', 'http://i.magaimg.net/img/16s2.jpg', '0000-00-00 00:00:00'),
('When Blue-Checkmarked Cucks try to tell you shooting Islamic TERRORISTS with bullets dipped in pigs blood is a \"War Crime\".', 'https://i.redd.it/imp9ta0aqcgz.gif', '0000-00-00 00:00:00'),
('The best part about labeling terrorist attacks as Alt Left is that leftards respond with: \"It wasnt Alt Left! It was Muslims!\"', 'https://i.redd.it/psc2cuijqcgz.jpg', '0000-00-00 00:00:00'),
('Washington Post gets one right!', 'https://i.redd.it/llvzoyhhqcgz.png', '0000-00-00 00:00:00'),
('Best time for free promotions!!', 'https://i.redd.it/kh8jm9niqcgz.jpg', '0000-00-00 00:00:00'),
('New images show leaked Vice plan for new Mount Rushmore', 'https://i.redd.it/2a1iokdmrcgz.jpg', '0000-00-00 00:00:00'),
('Fixed that for them. You know, just keeping them honest', 'https://i.redd.it/eo36im5frcgz.png', '0000-00-00 00:00:00'),
('‘I hope Trump is assassinated,’ Missouri Sen. Maria Chappelle-Nadal quickly deleted Facebook post, Enjoy your visit from the FBI', 'https://i.redd.it/r80ltn6crcgz.png', '0000-00-00 00:00:00'),
('Daaaamn, Islam! Back at it again with the white vans!', 'https://i.redd.it/brldkbizqcgz.jpg', '0000-00-00 00:00:00');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
