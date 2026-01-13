;Read Keypad
Kpad_rd movf	portb,w
	andlw	B'11110000'
	movwf	Kpad_pat
	bsf	status,rp0
	movlf	B'00001110'
	movwf	trisb
	bcf	status,rp0
	movlw	00
	movwf	portb
	movf	portb,w
	andlw	B'00001110'
	iorwf	Kpad_pat,1

;reset keypad interface
	bsf	status,rp0
	movlw	B'11110000'
	movwf	trisb
	bcf	status,rp0
	clrf	portb
	return
