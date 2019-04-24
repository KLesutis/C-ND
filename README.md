# C# ND v1.0


* Išbandyta List ir LinkedList konteineriai. Dėja Deque konteinerio sistemoje nėra.
* Išbandyta šių konteinerių rušiavimas ir išvestis į failus


## Testuota konteinerių programa su 10, 100, 1000, 10000 ir 100000 duomenų kiekių.

# 1 strategija

## List

| ms     | duomenys | atmintis  |
|--------|----------|-----------|
| 0      | 10       | 10813440  |
| 0      | 100      | 11403264  |
| 9      | 1000     | 15925248  |
| 2055   | 10000    | 35336192  |
| 281131 | 100000   | 112435200 |

## LinkendList
| ms     | duomenys | atmintis  |
|--------|----------|-----------|
| 0      | 10       | 89583616 |
| 0      | 100      | 89583616 |
| 7      | 1000     | 89939968 |
| 2129   | 10000    | 38408192  |
| 281531 | 100000   | 102027264 |

## Queue
| ms     | duomenys | atmintis  |
|--------|----------|-----------|
| 0      | 10       | 10784768 |
| 0      | 100      | 11440128 |
| 7      | 1000     | 15765504 |
| 2135   | 10000    | 34107392  |
| 284692 | 100000   | 257114112 |

Palyginus laiką, atrodo tokie patys duomenys. Bet Atmities atžvilgių, LinkedList smarkiai prankosta.


# 2 strategija

## List

| ms     | duomenys | atmintis  |
|--------|----------|-----------|
| 0      | 10       | 10731520  |
| 0      | 100      | 11386880  |
| 7      | 1000     | 15908864  |
| 2245   | 10000    | 35999744  |
| 293894 | 100000   | 145600512 |

## LinkendList
| ms     | duomenys | atmintis  |
|--------|----------|-----------|
| 0      | 10       | 145612800 |
| 0      | 100      | 145612800 |
| 6      | 1000     | 146137088 |
| 2331   | 10000    | 29065216  |
| 289109 | 100000   | 319815680 |

Šioje strategija yra nežymus nugalėtos LinkedList, kadangi jis geriau yra optimizuotas susitvarkyti tokias užduotis kaip Remove, dėl ko jo Laikas geresnis ir atmintis geriau išnaudota. Queue netinkamas šioje strategijoje, todėl, kad jis pašalina tik pradinį arba pabaigos elementą.


# Programos paleidimo instrukcija:
* Klonuoti šį projektą
* Paleisti projekta per VS IDE
* Sukompiliuoti projektą;
# Kaip naudotis programa:
* Sukompiliuoti projektą
* Atlikti papildomus veiksmus, jei to reikalauja programa;
