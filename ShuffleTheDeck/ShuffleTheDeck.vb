'Jamison Burton
'RCET 0265
'Spring 2022
'https://github.com/Reimonoe17/ShuffleTheDeck

Module ShuffleTheDeck

    Sub Main()

        Dim deck(3, 12) As Boolean
        Dim row As Integer
        Dim collumn As Integer
        Dim pull As Integer
        Dim reset As String
        Dim valid As Boolean
        Dim redraw As Boolean = False

        Do
            Console.WriteLine("How many cards would you like to draw?")
            pull = Console.ReadLine()

            Do
                For i = 1 To pull 'runs randomizer switching boolean array to true and repeats ranomizer if already true
                    Do
                        row = Roll(4)
                        collumn = Roll(13)
                    Loop Until deck(row, collumn) = False
                    deck(row, collumn) = True
                Next

                'runs the display subroutine
                DisplayDeck(deck)


                Console.WriteLine("To shuffle and draw again, enter 1. If satisfied, enter Q.")
                reset = Console.ReadLine()
                Select Case reset
                    Case "1"
                        Console.WriteLine("Shuffling deck...")
                        redraw = False
                        valid = True
                        Shuffle(deck)
                    Case "Q"
                        Console.WriteLine("Goodbye")
                        valid = True
                        redraw = True
                    Case Else
                        Console.WriteLine("Please enter a valid selection")
                        Console.WriteLine("")
                        valid = False
                End Select
            Loop Until valid = True

        Loop Until redraw = True
        Console.ReadLine()
    End Sub
    Function Roll(value As Integer) As Integer
        Randomize(DateTime.Now.Millisecond)
        Dim number As Integer
        number = CInt(Int((value * Rnd())))
        Return number
    End Function
    Sub DisplayDeck(ByRef deck(,) As Boolean)
        Dim header() As String = {"♠", "♥", "♣", "♦"}
        Dim face() As String = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"}
        Dim columnWidth As Integer = 3
        Dim columnData As String

        For row = 0 To deck.GetLength(1)
            For column = 0 To deck.GetLength(0) - 1
                Select Case row
                    Case 0 'first row is column headers
                        columnData = header(column).PadLeft(columnWidth)
                    Case Else
                        If Not deck(column, row - 1) Then 'mark if card has been drawn
                            columnData = "  "
                        Else 'show face value if card hasn't been drawn
                            columnData = face(row - 1)
                        End If
                End Select
                Console.Write(columnData.PadLeft(columnWidth) & " |")
            Next
            Console.WriteLine()
            Console.WriteLine(StrDup(20, "-"))
        Next

    End Sub

    Sub Shuffle(ByRef deck(,) As Boolean)
        For row = 0 To 3
            For column = 0 To 12
                deck(row, column) = False
            Next
        Next

    End Sub
End Module
