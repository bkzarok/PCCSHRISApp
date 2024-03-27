--IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Assignment'))
--BEGIN;
--    DROP TABLE [Assignment];
--END;
--GO

--CREATE TABLE [Assignment] (
--    [AssignmentID] INTEGER NOT NULL IDENTITY(1, 1),
--    [Unit] VARCHAR(MAX) NULL,
--    [PeriodFrom] VARCHAR(255) NULL,
--    [PeriodTo] VARCHAR(255) NULL,
--    [PositionHeld] VARCHAR(MAX) NULL,
--    [MilitaryNo] VARCHAR(MAX) NULL,
--    PRIMARY KEY ([AssignmentID])
--);
--GO

INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division4','Mar 1, 1989','Dec 10, 2016','HR','A56319'),
  ('Division4','May 26, 1976','Aug 10, 2014','Program','A25116'),
  ('Division2','Nov 17, 1989','Oct 17, 2013','Program','A23049'),
  ('Division3','Oct 15, 1983','Oct 21, 2010','Doctor','A18241'),
  ('Division1','Jan 12, 1981','Nov 9, 2020','Medical','A14697'),
  ('Division1','Jan 19, 1971','Oct 7, 2015','Officer','A86552'),
  ('Division3','Dec 21, 2001','Sep 22, 2011','Lawyer','A29456'),
  ('Division2','Jul 27, 1970','Dec 19, 2011','Program','A21485'),
  ('Division5','Oct 4, 1989','Aug 16, 2016','HR','A18631'),
  ('Division1','Oct 21, 1984','May 29, 2013','HR','A96685');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division5','Jun 14, 1983','Oct 31, 2019','Lawyer','A75785'),
  ('Division2','May 12, 1991','Aug 27, 2012','Manager','A58656'),
  ('Division1','Jun 23, 2001','Apr 23, 2019','HR','A01576'),
  ('Division2','Nov 12, 1991','Nov 4, 2012','Officer','A20232'),
  ('Division3','Aug 2, 1979','Oct 8, 2016','Program','A73373'),
  ('Division4','Feb 5, 1986','Jul 7, 2016','HR','A58670'),
  ('Division4','Feb 9, 1978','Feb 2, 2009','Program','A18631'),
  ('Division4','Jan 30, 1995','Sep 6, 2018','HR','A97487'),
  ('Division4','Jul 30, 1998','May 9, 2015','Assistant','A42885'),
  ('Division4','Dec 17, 1992','Jul 17, 2021','Lawyer','A28638');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division2','Dec 15, 1981','Jul 4, 2023','Officer','A85178'),
  ('Division2','Mar 2, 1995','May 30, 2013','Manager','A77336'),
  ('Division1','Feb 27, 1991','Nov 14, 2011','Officer','A78617'),
  ('Division3','Nov 10, 1995','Sep 19, 2011','Lawyer','A78116'),
  ('Division4','Aug 26, 1986','Mar 8, 2024','Officer','A74273'),
  ('Division3','Jan 25, 2004','May 12, 2024','Medical','A74721'),
  ('Division2','Aug 8, 1978','May 25, 2015','Doctor','A95143'),
  ('Division2','Feb 9, 1973','Mar 12, 2020','Assistant','A35122'),
  ('Division3','Mar 15, 1991','Dec 19, 2019','HR','A87059'),
  ('Division5','May 27, 2001','Oct 31, 2020','Program','A56548');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division3','Jul 14, 1988','May 26, 2017','Assistant','A39768'),
  ('Division4','Feb 18, 2000','Jun 7, 2008','Manager','A53427'),
  ('Division3','May 1, 1981','Aug 18, 2010','Program','A18241'),
  ('Division4','Dec 20, 1973','Aug 6, 2020','Officer','A56364'),
  ('Division2','May 9, 1982','May 4, 2017','Manager','A34525'),
  ('Division3','Nov 9, 1996','Jun 27, 2022','Doctor','A24425'),
  ('Division4','Mar 26, 1999','Oct 11, 2014','Manager','A32528'),
  ('Division3','Jan 10, 1986','Aug 27, 2013','Officer','A43531'),
  ('Division2','Mar 2, 2004','Aug 28, 2012','Officer','A79815'),
  ('Division4','Jul 14, 1988','Jul 31, 2013','Medical','A58723');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division1','Sep 21, 1993','Sep 10, 2014','Manager','A65630'),
  ('Division3','Jun 26, 1980','Jan 12, 2020','Officer','A47953'),
  ('Division3','Sep 27, 1996','Aug 15, 2009','Lawyer','A68421'),
  ('Division3','Oct 17, 2002','Apr 20, 2013','Manager','A28638'),
  ('Division3','Jul 4, 1996','Jul 27, 2017','Assistant','A55893'),
  ('Division3','Aug 2, 1987','Nov 21, 2009','HR','A73942'),
  ('Division3','Jun 6, 1990','Apr 23, 2015','Lawyer','A18446'),
  ('Division1','Aug 7, 1993','Apr 24, 2015','Officer','A61357'),
  ('Division2','Jun 11, 1992','Dec 31, 2023','Officer','A32637'),
  ('Division2','Jun 10, 1984','Oct 28, 2011','Program','A77336');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division4','Sep 22, 1996','Apr 14, 2013','HR','A68421'),
  ('Division4','Jun 3, 1997','Mar 4, 2012','Manager','A75565'),
  ('Division4','Jun 11, 1981','Jan 10, 2016','Assistant','A74582'),
  ('Division3','Jan 11, 1986','Sep 10, 2011','Officer','A77193'),
  ('Division5','Jan 1, 1984','Apr 27, 2013','Manager','A12588'),
  ('Division5','Jun 5, 1972','Apr 13, 2023','Officer','A56548'),
  ('Division2','Feb 26, 1993','Jun 19, 2018','Program','A60219'),
  ('Division3','Mar 15, 1997','Feb 11, 2025','Manager','A86194'),
  ('Division5','Nov 27, 1980','Nov 21, 2022','Medical','A20082'),
  ('Division2','Mar 6, 1991','Oct 20, 2019','Assistant','A43531');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division3','Jan 29, 1989','Mar 25, 2015','HR','A83682'),
  ('Division2','Jul 27, 1976','Jul 12, 2013','Officer','A58309'),
  ('Division2','Aug 3, 1978','Jul 6, 2022','Lawyer','A55476'),
  ('Division3','Apr 19, 1981','Feb 25, 2015','Medical','A97379'),
  ('Division3','Dec 8, 1985','Aug 1, 2011','HR','A45710'),
  ('Division2','Nov 6, 1979','Dec 13, 2024','Medical','A72651'),
  ('Division5','Oct 14, 1981','Sep 24, 2009','Officer','A67229'),
  ('Division4','Jul 31, 1973','Apr 25, 2010','Program','A52835'),
  ('Division2','Nov 20, 1978','Mar 28, 2023','Officer','A23163'),
  ('Division2','May 2, 1987','May 31, 2019','Assistant','A31745');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division3','Feb 7, 1989','Oct 14, 2023','HR','A23640'),
  ('Division4','Nov 12, 1975','Dec 12, 2024','HR','A88546'),
  ('Division2','Dec 4, 1990','Feb 2, 2020','Officer','A54289'),
  ('Division3','Jun 19, 1992','Apr 14, 2012','Medical','A65572'),
  ('Division3','Feb 23, 1981','Jan 16, 2019','Officer','A52317'),
  ('Division4','Mar 14, 1972','Aug 20, 2024','Medical','A11163'),
  ('Division5','Nov 12, 2002','Feb 27, 2025','Officer','A47579'),
  ('Division4','May 5, 1985','Apr 30, 2009','Lawyer','A85568'),
  ('Division3','Jan 12, 1988','Jun 12, 2012','Lawyer','A27447'),
  ('Division2','Oct 17, 2002','Sep 15, 2015','Officer','A43893');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division1','Mar 7, 1990','Feb 6, 2020','Officer','A21485'),
  ('Division1','Jun 6, 1972','Jun 9, 2023','Manager','A22425'),
  ('Division2','Aug 2, 1982','Sep 20, 2010','Medical','A87059'),
  ('Division3','Sep 20, 2003','Jan 13, 2016','Medical','A62354'),
  ('Division3','Sep 17, 1972','Feb 3, 2015','Officer','A27337'),
  ('Division2','Aug 28, 1986','Jun 24, 2009','Manager','A52353'),
  ('Division2','Jan 1, 1990','May 1, 2020','Medical','A97454'),
  ('Division3','Apr 23, 1995','Jan 25, 2014','Officer','A28752'),
  ('Division4','Jul 25, 1980','Oct 18, 2021','Assistant','A86448'),
  ('Division2','Mar 8, 1973','Oct 30, 2013','Lawyer','A85969');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division5','Jun 17, 2000','Jun 23, 2021','Lawyer','A74224'),
  ('Division4','Aug 10, 1976','Sep 23, 2011','Program','A52477'),
  ('Division5','Jun 30, 1971','Oct 20, 2013','Medical','A76571'),
  ('Division3','Mar 29, 1999','Jan 4, 2025','Program','A61638'),
  ('Division1','Apr 7, 1986','Apr 22, 2024','Doctor','A62847'),
  ('Division2','Nov 8, 1999','Aug 6, 2024','Assistant','A65550'),
  ('Division5','Jun 20, 1994','Feb 5, 2010','HR','A23049'),
  ('Division4','Sep 29, 1983','Dec 8, 2023','Program','A36473'),
  ('Division3','Jul 22, 1973','Dec 4, 2021','Lawyer','A56377'),
  ('Division3','May 13, 1970','Jul 17, 2014','Manager','A35122');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division4','May 19, 1999','Sep 14, 2012','HR','A77193'),
  ('Division1','Sep 2, 1974','Nov 22, 2009','Manager','A19268'),
  ('Division2','Jan 22, 1972','Mar 27, 2020','Assistant','A74582'),
  ('Division4','May 2, 1972','Jun 14, 2011','Officer','A54674'),
  ('Division5','Sep 3, 1993','Jun 19, 2019','Officer','A65393'),
  ('Division5','Jan 31, 1975','Sep 26, 2020','Medical','A65630'),
  ('Division3','Jan 23, 1974','Jun 27, 2013','HR','A50335'),
  ('Division1','Jun 18, 1991','Aug 24, 2020','Officer','A20048'),
  ('Division4','Dec 19, 1982','Nov 15, 2010','HR','A20232'),
  ('Division3','May 20, 1989','Apr 2, 2014','Manager','A26660');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division4','Oct 19, 1995','Jul 7, 2009','Assistant','A29215'),
  ('Division1','Oct 25, 1973','Jan 30, 2010','Manager','A53171'),
  ('Division3','Dec 3, 1987','Aug 3, 2019','Manager','A39768'),
  ('Division5','Jul 13, 1979','Feb 25, 2021','Officer','A45710'),
  ('Division5','Mar 27, 1978','Dec 23, 2019','Assistant','A28585'),
  ('Division2','Jun 30, 1994','Sep 23, 2008','Program','A92617'),
  ('Division4','Jul 21, 1973','Sep 28, 2009','Manager','A82144'),
  ('Division1','Dec 14, 1972','Apr 9, 2017','Lawyer','A79494'),
  ('Division1','May 2, 1974','Aug 19, 2019','Lawyer','A65288'),
  ('Division4','Feb 16, 1976','Dec 27, 2016','Assistant','A17469');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division1','Jul 8, 1982','Apr 7, 2015','Manager','A76571'),
  ('Division2','Aug 31, 1971','May 5, 2008','Assistant','A64955'),
  ('Division2','May 17, 1998','Feb 8, 2011','Officer','A83682'),
  ('Division4','Oct 9, 1989','Mar 10, 2019','Manager','A75785'),
  ('Division2','May 8, 1981','Nov 8, 2010','Medical','A49222'),
  ('Division4','Aug 18, 1993','Feb 24, 2021','Lawyer','A04280'),
  ('Division5','Aug 16, 2002','Sep 17, 2011','Program','A73337'),
  ('Division2','Apr 15, 1997','Jul 5, 2013','Officer','A13843'),
  ('Division1','Feb 13, 1987','Jun 15, 2012','Lawyer','A94951'),
  ('Division3','Oct 12, 1993','Apr 9, 2022','Program','A47732');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division2','Feb 28, 2004','Dec 28, 2013','Manager','A72577'),
  ('Division2','Jul 24, 1973','Feb 9, 2015','Assistant','A16354'),
  ('Division3','Dec 30, 1998','Oct 2, 2014','Manager','A25331'),
  ('Division2','Jan 20, 1996','Jan 20, 2022','Program','A88214'),
  ('Division3','Jul 3, 1998','Feb 2, 2013','Medical','A85568'),
  ('Division3','Jan 2, 1999','May 4, 2013','Manager','A91701'),
  ('Division1','Aug 4, 1977','Dec 13, 2024','Lawyer','A49546'),
  ('Division5','Apr 21, 1984','Apr 19, 2008','HR','A64160'),
  ('Division5','Sep 4, 1971','Jan 23, 2013','Lawyer','A28638'),
  ('Division2','Apr 10, 1971','Jan 19, 2020','Officer','A38524');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division4','Dec 19, 1974','Feb 18, 2021','Doctor','A66666'),
  ('Division4','May 11, 1974','Mar 5, 2009','Doctor','A56075'),
  ('Division4','Oct 14, 1986','Aug 23, 2015','HR','A53794'),
  ('Division2','Jul 30, 2000','Apr 10, 2011','Assistant','A57029'),
  ('Division2','Oct 24, 1987','Jan 19, 2016','Manager','A29456'),
  ('Division4','Sep 2, 1997','Apr 4, 2014','Assistant','A49603'),
  ('Division2','Dec 17, 2000','Apr 15, 2024','Assistant','A86114'),
  ('Division4','May 30, 1995','Apr 3, 2021','Assistant','A34097'),
  ('Division4','Nov 30, 1991','Nov 25, 2011','Lawyer','A55645'),
  ('Division5','Aug 8, 1975','Oct 6, 2011','Medical','A31792');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division3','Nov 4, 1989','Jan 4, 2009','Lawyer','A82817'),
  ('Division3','Jul 4, 1974','Dec 24, 2014','Program','A25707'),
  ('Division1','May 17, 1994','Sep 8, 2023','Assistant','A79548'),
  ('Division3','May 3, 1987','Jan 27, 2025','Assistant','A84768'),
  ('Division2','Oct 11, 1988','Jun 22, 2016','Lawyer','A18241'),
  ('Division3','Apr 13, 1986','Sep 9, 2009','Program','A66613'),
  ('Division3','Sep 22, 1985','Apr 13, 2009','Program','A06338'),
  ('Division4','Dec 17, 1988','Jul 21, 2016','Manager','A39768'),
  ('Division2','Sep 16, 1999','Aug 25, 2023','Officer','A89952'),
  ('Division5','Aug 14, 1995','Jun 8, 2014','Manager','A22425');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division3','Nov 30, 2001','Jul 20, 2021','Officer','A13910'),
  ('Division3','Jan 16, 1973','Dec 29, 2015','Assistant','A34780'),
  ('Division3','Jul 17, 1972','May 17, 2019','Officer','A09831'),
  ('Division4','Sep 27, 1994','Jun 3, 2012','Officer','A50335'),
  ('Division5','Apr 7, 1991','Aug 17, 2018','Lawyer','A82144'),
  ('Division2','Apr 15, 1978','Nov 7, 2013','Manager','A92147'),
  ('Division4','Oct 16, 1983','Jan 2, 2023','Lawyer','A73373'),
  ('Division4','May 23, 2002','Oct 6, 2024','Assistant','A86553'),
  ('Division5','Oct 29, 1978','Jul 11, 2011','Program','A36604'),
  ('Division1','Sep 16, 1977','Jul 31, 2009','Manager','A34565');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division2','Mar 3, 1981','Jun 13, 2018','Officer','A58670'),
  ('Division4','Dec 21, 1992','Oct 30, 2016','Lawyer','A22425'),
  ('Division3','Mar 26, 2002','Mar 2, 2016','Lawyer','A28142'),
  ('Division1','Dec 18, 1978','Apr 2, 2016','Manager','A65343'),
  ('Division2','Sep 12, 1988','Nov 2, 2022','Manager','A54635'),
  ('Division3','May 10, 2002','Jan 12, 2021','Manager','A06338'),
  ('Division3','Jan 15, 1971','Dec 14, 2015','Officer','A33694'),
  ('Division4','Oct 27, 1985','Aug 1, 2021','Medical','A61488'),
  ('Division4','Mar 11, 1971','Feb 15, 2022','Doctor','A46631'),
  ('Division4','Aug 10, 1993','Jun 21, 2015','Lawyer','A88133');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division4','Nov 29, 1975','Jul 11, 2023','Manager','A08879'),
  ('Division4','May 30, 2003','May 22, 2018','Officer','A34219'),
  ('Division2','Apr 15, 1989','Jul 2, 2022','HR','A82817'),
  ('Division2','Apr 17, 1972','Mar 9, 2020','Medical','A76571'),
  ('Division2','Oct 12, 1981','Feb 17, 2017','Manager','A19268'),
  ('Division1','Mar 10, 1974','Apr 20, 2015','Manager','A52646'),
  ('Division4','Jul 5, 1999','Aug 31, 2014','Assistant','A71281'),
  ('Division4','Jun 12, 1995','May 27, 2016','Lawyer','A95001'),
  ('Division3','Feb 20, 1987','Nov 17, 2023','Manager','A85284'),
  ('Division2','Nov 27, 1981','Mar 6, 2023','Doctor','A66498');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division1','Apr 8, 1989','Jun 4, 2017','Assistant','A81334'),
  ('Division5','May 8, 2003','Oct 5, 2010','Assistant','A21567'),
  ('Division5','Apr 16, 1985','Jul 25, 2016','HR','A82273'),
  ('Division3','Feb 26, 1990','Jan 28, 2010','Medical','A23999'),
  ('Division3','Nov 29, 1976','Jun 4, 2020','Officer','A57029'),
  ('Division4','Apr 2, 1975','Jul 30, 2014','Doctor','A53438'),
  ('Division4','Aug 26, 1986','Oct 6, 2020','Officer','A82273'),
  ('Division1','Oct 14, 1988','Mar 16, 2018','Officer','A82271'),
  ('Division3','Jan 9, 2002','Oct 13, 2017','Program','A23999'),
  ('Division4','Apr 5, 1970','Aug 11, 2014','Program','A59148');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division2','Nov 19, 2003','Mar 10, 2016','Officer','A07060'),
  ('Division3','Jan 25, 1993','Dec 24, 2012','Assistant','A67151'),
  ('Division5','Apr 1, 1972','Nov 17, 2012','Assistant','A13910'),
  ('Division5','Nov 24, 1977','Feb 12, 2025','Medical','A19614'),
  ('Division3','Dec 30, 1977','Sep 7, 2011','Manager','A82144'),
  ('Division2','Jul 26, 1993','Feb 15, 2025','Officer','A74273'),
  ('Division2','May 20, 1973','Feb 26, 2012','Medical','A21618'),
  ('Division2','Apr 10, 1985','Apr 15, 2022','Officer','A38524'),
  ('Division3','Dec 20, 1998','Sep 5, 2019','HR','A13972'),
  ('Division2','Feb 10, 1976','Aug 25, 2011','Officer','A57424');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division5','Jan 15, 1974','Aug 31, 2020','Officer','A73373'),
  ('Division1','Sep 29, 1993','Apr 27, 2013','Assistant','A63587'),
  ('Division4','Oct 5, 1973','Nov 1, 2023','Assistant','A20082'),
  ('Division5','May 27, 1977','Jul 8, 2011','Medical','A45710'),
  ('Division3','Dec 27, 1995','Nov 7, 2016','Program','A61357'),
  ('Division5','May 17, 1977','Feb 7, 2022','Officer','A33694'),
  ('Division3','Jan 1, 1979','Oct 31, 2017','Assistant','A32880'),
  ('Division3','Dec 27, 1983','Jun 19, 2010','HR','A19216'),
  ('Division2','Mar 3, 1990','Dec 19, 2014','Program','A55893'),
  ('Division5','Apr 7, 1988','Jul 23, 2024','Assistant','A19362');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division3','Mar 23, 1983','Nov 20, 2022','Medical','A65550'),
  ('Division2','Dec 3, 1981','Jun 28, 2012','Assistant','A47953'),
  ('Division4','Mar 2, 1997','Mar 11, 2010','Officer','A30113'),
  ('Division2','Jul 3, 1992','Nov 6, 2017','Manager','A34433'),
  ('Division5','Oct 29, 1972','Jun 25, 2024','Medical','A76767'),
  ('Division4','Jan 17, 1976','Jul 11, 2013','Medical','A20048'),
  ('Division2','Apr 25, 2000','Sep 26, 2017','HR','A66884'),
  ('Division1','May 20, 1998','Mar 18, 2018','Officer','A66666'),
  ('Division1','Apr 9, 1975','Oct 22, 2008','Officer','A83682'),
  ('Division1','Jan 7, 2000','Oct 14, 2008','HR','A23163');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division2','Oct 30, 1994','Apr 10, 2010','Officer','A12714'),
  ('Division2','Oct 3, 2003','Jul 16, 2016','Officer','A73337'),
  ('Division2','Sep 14, 1975','Mar 6, 2010','Program','A32528'),
  ('Division4','Aug 2, 1997','May 5, 2017','Program','A45812'),
  ('Division3','Oct 17, 1970','May 16, 2023','Officer','A85607'),
  ('Division4','Nov 15, 1977','Jan 19, 2017','Manager','A14556'),
  ('Division3','Aug 9, 1971','Sep 19, 2021','Assistant','A87059'),
  ('Division2','Mar 8, 1994','May 29, 2017','Doctor','A37024'),
  ('Division2','Mar 24, 1975','Feb 17, 2009','Officer','A58309'),
  ('Division3','Jul 6, 1982','Dec 29, 2022','Program','A41452');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division2','Feb 3, 1973','May 18, 2014','Manager','A72577'),
  ('Division2','Jun 29, 1984','May 29, 2013','Doctor','A53794'),
  ('Division4','Feb 26, 1983','Mar 3, 2016','Doctor','A25505'),
  ('Division5','Jul 4, 1974','Apr 6, 2008','Doctor','A70729'),
  ('Division4','Aug 12, 1975','Nov 15, 2021','Assistant','A28436'),
  ('Division4','Aug 18, 1978','Mar 16, 2020','Assistant','A63530'),
  ('Division4','Dec 21, 1994','Jun 2, 2020','HR','A45128'),
  ('Division5','Apr 25, 1971','Oct 25, 2018','HR','A21272'),
  ('Division1','Dec 9, 1978','May 24, 2023','Lawyer','A11022'),
  ('Division2','Jul 3, 1972','May 17, 2010','Officer','A49222');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division2','Nov 5, 1983','Mar 15, 2017','Manager','A66498'),
  ('Division3','Jun 21, 1979','Sep 21, 2009','Program','A17469'),
  ('Division3','Jan 22, 1978','Jan 13, 2025','Program','A22222'),
  ('Division3','Nov 26, 1990','Oct 16, 2012','Medical','A14013'),
  ('Division3','Jul 20, 1975','Aug 20, 2018','Manager','A76586'),
  ('Division2','Oct 7, 1991','Apr 10, 2014','HR','A55145'),
  ('Division2','Jul 23, 1998','Oct 8, 2008','Manager','A32880'),
  ('Division2','Apr 8, 1974','Feb 6, 2010','Officer','A64652'),
  ('Division2','May 14, 2002','Oct 6, 2015','Manager','A07930'),
  ('Division3','Jan 26, 1975','Nov 1, 2019','Manager','A86194');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division1','Oct 13, 1987','Dec 5, 2008','Manager','A66613'),
  ('Division3','Apr 24, 1987','Aug 10, 2017','Officer','A49546'),
  ('Division2','Dec 1, 1994','Jul 29, 2011','Officer','A78116'),
  ('Division5','May 16, 1992','Oct 4, 2016','Lawyer','A86521'),
  ('Division3','Jul 29, 1987','Feb 5, 2017','Lawyer','A53427'),
  ('Division3','Nov 1, 1976','Feb 15, 2020','HR','A55678'),
  ('Division2','Feb 21, 2001','May 11, 2009','Medical','A11661'),
  ('Division4','Aug 15, 1976','Jan 28, 2018','Medical','A54289'),
  ('Division4','Jul 4, 1973','Sep 13, 2010','Officer','A54674'),
  ('Division4','Apr 28, 1978','Mar 14, 2015','Medical','A13910');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division5','Sep 27, 1972','Nov 15, 2024','Assistant','A35462'),
  ('Division3','Jun 19, 1986','Jun 13, 2021','Officer','A68421'),
  ('Division2','Dec 22, 1987','Oct 10, 2015','Program','A88546'),
  ('Division3','Nov 3, 1991','Aug 8, 2016','Manager','A37697'),
  ('Division3','Mar 9, 1974','Feb 8, 2022','Doctor','A04280'),
  ('Division3','Sep 1, 1996','May 2, 2012','Officer','A71749'),
  ('Division2','Dec 18, 1988','Mar 27, 2024','Manager','A70217'),
  ('Division2','Jul 5, 2000','Nov 22, 2009','HR','A73373'),
  ('Division3','Feb 8, 1972','Dec 9, 2015','Officer','A36545'),
  ('Division5','May 30, 1996','Jan 20, 2012','Lawyer','A70217');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division4','May 6, 2003','Dec 29, 2020','Officer','A46865'),
  ('Division2','May 8, 1997','May 13, 2008','Medical','A24425'),
  ('Division3','Nov 25, 1985','Jun 24, 2016','Lawyer','A23163'),
  ('Division1','Sep 13, 1982','Jul 30, 2019','Officer','A74582'),
  ('Division2','Aug 10, 2002','Oct 30, 2008','Lawyer','A56319'),
  ('Division3','May 7, 1999','Aug 31, 2011','Assistant','A85178'),
  ('Division3','Jul 9, 2003','Jan 3, 2009','HR','A79548'),
  ('Division2','Mar 1, 1981','May 22, 2019','Assistant','A94806'),
  ('Division4','Nov 12, 1972','Jun 23, 2008','Medical','A62724'),
  ('Division2','Aug 18, 1976','May 18, 2020','Assistant','A12826');
INSERT INTO [Assignment] (Unit,PeriodFrom,PeriodTo,PositionHeld,MilitaryNo)
VALUES
  ('Division4','Mar 5, 1997','May 8, 2017','Manager','A28883'),
  ('Division3','Mar 16, 2001','Jan 24, 2013','Officer','A66752'),
  ('Division3','Sep 25, 1990','Dec 31, 2022','Doctor','A29983'),
  ('Division3','Mar 8, 1995','Nov 28, 2021','Officer','A43531'),
  ('Division2','Sep 12, 1971','Aug 28, 2009','Officer','A08315'),
  ('Division2','Oct 4, 1995','May 29, 2021','Assistant','A19268'),
  ('Division4','May 7, 1990','Jun 23, 2024','Manager','A32528'),
  ('Division2','Jan 27, 1989','Nov 11, 2013','Program','A43531'),
  ('Division3','Jun 6, 1983','Nov 2, 2015','Medical','A33557'),
  ('Division1','Nov 21, 1991','Jan 17, 2017','Doctor','A94811');
