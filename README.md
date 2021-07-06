# Design-pattern-basic-principle
<h1>設計模式, 基本7大原則</h1>

## SRP 單一則責任原則 Single Responsibility Principle
>一個類只負責一件事 且只有一個原因修改這個類

<br><br/>

## OCP 開放封閉原則 Open/Close Principle
>開放擴增, 封閉修改

<br><br/>

## LSP 里氏替換原則 Liskov's Substitution Principle
>子類別必須能夠替換父類別, 並且行為正常

<br><br/>

## ISP 介面隔離原則 Interface Segregation Principle
>不應該強迫用戶去依賴他們未使用的方法

<br><br/>

## DIP 依賴反轉原則 Dependency Inversion Principle
>高層模組不應該依賴低層模組, 他們都應該依賴抽象
抽象不應該依賴細節(實作類), 細節應該依賴抽象(interface 或 abstract)

<br><br/>

## LKP 最少知識原則 Least Knowledge Principle
>已經成形的操作流程就封裝起來, 一個物件應該對其他物件有最少的瞭解

<br><br/>

## CARP 合成聚合復用原則 Composite/Aggregate Reuse Principle
>盡量使用組合(contains-a)/聚合(has-a)方式來代替繼承(is-a)來達到重複使用的目的
