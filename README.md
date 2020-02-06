## 5. feladat

egész: hivni 
hivni := 0

egész: kezdes
kezdes := uzenetek[0].o

egész: i 
i := 0

Ciklus amíg i < darab
	egész: db = 0

	Ciklus amíg i < darab és uzenet[i].o == kezdes
		i++
		db++
	Ciklus vége

	Ha db > 10 akkor
		hivni = hivni + db - 10
	Feltétel vége

	kezdes = uzenet[i].o
Ciklus vége

## 6. feladat

Lista: hivasok

Ciklus i:= 0-tól i < darab
	Ha uzenetek[i].t == "123456789" akkor
		hivasok.add( o* 60 + p)
	Feltétel vége
Ciklus vége

Ha hivasok.Count <= 1 akkor
	Kiir: Nincs elegendő üzenet
Egyébként
	egész: max  = 0

	Ciklus i := 1-től i < hivasok.Count
		egész: eltelt
		eltelt = hivasok[i] - hivasok[i-1]
		Ha max < eltelt akkor
			max := eltelt
		Feltétel vége
	Ciklus vége

	egész : ora
	egész : perc

	ora := max / 60
	perc := max - (ora * 60)

	Kiir: ora:perc

Feltétel vége


## 8. feladat

egész: i
i := 0
StreamWrite: ki

Ciklus amíg i < darab 
	szöveg: telefonszam
	telefonszam := uzenetek[i].t

	Kiir.ki : telefonszam
	Ciklus i < darab és telefonszam == uzenetek[i].t
		Kiir.ki: o:p uzenet
		i++
	Ciklus vége
Ciklus vége

ki.close
























