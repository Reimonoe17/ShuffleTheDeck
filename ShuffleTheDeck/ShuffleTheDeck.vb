'Jamison Burton
'RCET 0265
'Spring 2022
'https://github.com/Reimonoe17/ShuffleTheDeck

Module ShuffleTheDeck

    Sub Main()
        Dim Card(51) As String
        Dim suit() As String = {"♠", "♥", "♣", "♦"}
        Dim value() As String = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"}

        'Assigns card value to each element of the array
        For i = LBound(Card) To UBound(Card)
            For j = LBound(suit) To UBound(suit)
                For k = LBound(value) To UBound(value)
                    Card(i) &= $"{suit(j)}{value(k)}"
                    i += 1
                Next
            Next
        Next

        For i = LBound(Card) To UBound(Card)
            Console.WriteLine(Card(i))
        Next

        For i = 1 To 26
            Console.WriteLine("Take a card, any card!           (press enter)")
            Console.WriteLine(DrawACard)
        Next

        Console.ReadLine()
    End Sub

    Function DrawACard() As Integer
        Randomize()
        Static Dim pull(25) As Integer
        Static Dim pullNumber As Integer
        Dim newValue As Boolean = False
        Dim value As Integer

        pullNumber += 1

        Do
            value = CInt(Int((52 * Rnd())))
            pull(pullNumber) = value

            For i = LBound(pull) To UBound(pull)
                If pull(i) <> value Then
                    newValue = True
                ElseIf pull(i) = value Then
                    newValue = False
                End If
            Next
        Loop Until newValue = True

        Return value 'Outputs a random value between 0 and 51
    End Function

End Module
