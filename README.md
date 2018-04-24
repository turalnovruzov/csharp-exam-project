# csharp-exam-project
C# basics exam project

#HR Match

Bu proqram iscilerle is veren arasindaki elaqeni qurmaq ucundur.

	1.  Proqram sayesinde hem isciler hem de is verenler qeydiyyatdan kecir. Proqrama acilan kimi sorusur Sign in, Sign up or Exit. Eger Sign up secilse asagidaki emeliyyatlar olur. 
		
	    1.1 Isciler ve ya is verenler qeydiyyatdan kecdikleri zaman baslangic olaraq 
		- Username
		- Email (emailin formati regex le yoxlanilmalidir, format sehvdirse yeniden duzgun daxil etmesini istemelidir, Duzgun: muradheyderov@gmail.com)
		- Status: 1. Isci 2. Isveren
		- Sifre (
		   -en azi bir boyuk herf olmalidir, 
                   -bir reqem, bir simvol (_+-/. ve s.) olamlidir, 
                   -maksimum uzunluq 15 simvol, Duzgun: Murad_894
                  )

		- tekrar password (yuxaridaki ile eyniliyi yoxlamaq ucun)
		- 4 simvoldan (reqem ve herf) ibaret random kod (bu kod random olaraq avtomatik yaradilacaq ve userden bu kodun eynisinin yazilmasini teleb edecek, Duzgun: w3Kp, 5Gq7)

		melumatlarini daxil edirler. 

	2.  Eger isci kimi qeydiyyatdan kecibse esas menyuda bunlar gorsenecek

	    2.1. CV yerlesdir (Bu bolme secilen zaman asagidaki melumatlar elave olunmalidir)

		- Ad
		- Soyad
		- Cins (Kisi, Qadin)
		- Yas 
		- Tehsil (orta, natamam ali, ali)
		- Is tecrubesi 
		{
		     1 ilden asagi,
		     1 ilden - 3 ile qeder
		     3 ilden - 5 ile qeder
		     5 ilden daha cox
		}
		- Kateqoriya (Evvelceden teyin olunur. Meselen, Hekim, Jurnalist, IT mutexessis, Tercumeci ve s.)
		- Seher (Baki, Gence, Seki ve s.)
		- Minimum emek haqqi 
		- Mobil telefon (+994 50/51/55/70/77 5555555(7) bu formati desteklemelidir)

	    2.2. Is axtar (CV melumatlarina gore)
		
		2.2.1. Isci bu bolmeni secdiyi zaman onun cv melumatlarina en cox uygun is elanlarini cixartmalidir. Eger isci elandaki sertleri odeyirse o elan gorsenmelidir. 
		
	    2.3. Search 
		 
		2.3.1. Yuxarida qeyd olunmus melumatlarin her hansi birine gore axtaris (Kateqoriya, Tehsil, Seher, Emek haqqi, Is tecrubesi)

	    2.4. Melumatlari goster

		- CV de daxil eledikleri melumatlari seliqeli sekilde gostermelidir. 

	    2.5. Butun elanlari goster 
		
		2.5.1. Elanlarin adini gostermelidir. Meselen,
		{
		     1. Hekim
		     2. Jurnalist 
		     3. Tercumeci 
		     ve s.

		     Elanin reqemini secdiyimiz anda hemen is elaninin detallarini gostermelidir. 
		} 

	   	Secilen elanin sonunda

		     - Muraciet et (y/n)   

		     olmalidir eger y secse elana muraciet etmelidir n secidiyi zaman ise yeniden butun elanlari gostermelidir.

	     2.6. Log out. (User in cixis edib birinci menyuya qayitmagi ucun)

	     2.7. Muraciet olunmus elanlar. (Muraciet elediyin butun elanlarin siyahisi ve statusu) // Inactive

	     2.8. Teklifler // Inactive

	3.  Eger is veren kimi qeydiyyatdan kecibse esas menyuda bunlar gorsenecek
	    
	    3.1. Elan yerlesdir (Is veren bir nece elan yerlesdire biler)
		
		- Is elanin adi
		- Sirketin adi
	    	- Kateqoriya
		- Is barede melumat
		- Seher
		- Maas 
		- Yas
		- Tehsil (orta, natamam ali, ali)
		- Is tecrubesi 
		- Mobil telefon (+994 50/51/55/70/77 5555555(7) bu formati desteklemelidir)
		
	     3.2 Isci axtar (CV melumatlarina gore) //Inactive
		
	     3.3 Search (Yuxarida qeyd olunmus melumatlarin her hansi birine gore axtaris (Kateqoriya, Tehsil, Seher, Emek haqqi, Is tecrubesi)) // Inactive

	     3.3. Muracietler (Bu bolmede is elanina edilen muracietler gorsenmelidir (Is elanin adi, Muraciet eden isci ve onun melumatlari))
	
    	     3.4. Log out. (User in cixis edib birinci menyuya qayitmagi ucun)

	4. Proqram sonunda Exit secilen zaman butun isci ve is verenin melumatlini serialise ederek json ve ya xml formatinda fayla yazmaq lazimdir. Iscileri ayri fayla is vereni ise ayri fayla. Proqram ise dusen zaman da hemen melumatlari oxuyub proqrami qaldigi yerden davam etdirmek lazimdir.
