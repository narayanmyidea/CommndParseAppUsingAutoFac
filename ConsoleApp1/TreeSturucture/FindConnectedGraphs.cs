using System;
using System.Globalization;

namespace TreeSturucture
{



// <summary>This class demonstrates how to discover the connectivity 
// between shapes in a diagram using a breadth-first traversal.</summary>
    public class FindConnectedGraphs
    {

        public static void OpenApp()
        {
            visioApplication =
                new Microsoft.Office.Interop.Visio.Application();

            var d=visioApplication.Documents.Add("d://Drawing1.vsdx");
            DemoFindConnectedGraphs(d.Pages[1]);
        }
        /// <summary>This method is the class constructor.</summary>
        public FindConnectedGraphs()
        {
            // No initialization is required.
        }
        private static Microsoft.Office.Interop.Visio.Application visioApplication;

        private static System.Collections.Generic.List<int> processedShapeIDs;
        private static System.Collections.Generic.List<int> rootShapeIDs;
        private static System.Collections.Generic.List<int> circuitShapeIDs;
        private static System.Collections.Generic.Queue<int> queuedShapeIDs;
        private static Microsoft.Office.Interop.Visio.Shapes pageShapes;



        /// <summary> This method performs a breadth-first traversal of each
        /// graph found on the active page of the given document. Graphs are
        /// identified first by finding root nodes (shapes with only outgoing 
        /// connections that are top level shapes). After these graphs have
        /// been processed the remaining top level shapes with both outgoing 
        /// and incoming connections are traversed in case they are part of
        /// closed circuit graphs. For each graph found, the debug output shows
        /// a line of dashes followed by a listing of the shapes visited in 
        /// the traversal. The text of the shape is output, along with the
        /// shape ID. Also, connectors that are traversed have their text 
        /// output. </summary> 
        /// <param name="pageToSearch">The Visio page
        /// containing the graphs.</param>
        /// <returns>True if the procedure completes successfully</returns>
        public static bool DemoFindConnectedGraphs(Microsoft.Office.Interop.Visio.Page pageToSearch)
        {
            int[] incomingShapeIDs;
            int[] outgoingShapeIDs;


            if (pageToSearch == null)
            {
                return false;
            }

            try
            {
                // Initialize shape graph
                processedShapeIDs = new System.Collections.Generic.List<int>();
                rootShapeIDs = new System.Collections.Generic.List<int>();
                circuitShapeIDs = new System.Collections.Generic.List<int>();
                queuedShapeIDs = new System.Collections.Generic.Queue<int>();
                pageShapes = pageToSearch.Shapes;

                System.Diagnostics.Debug.WriteLine("Connected Shape Graphs");

                // Iterate through shapes on the page looking for shapes with 
                // only outgoing connectors
                foreach (Microsoft.Office.Interop.Visio.Shape currentShape in pageShapes)
                {
                    // Find the 2D shapes on the page
                    if (currentShape.OneD == 0)
                    {
                        // Identify the shapes that are roots (no incoming 
                        // connections and at least one outgoing connection)
                        incomingShapeIDs = (int[]) currentShape.ConnectedShapes(
                            Microsoft.Office.Interop.Visio.VisConnectedShapesFlags.visConnectedShapesIncomingNodes,
                            "");
                        // Also identify the shapes that are connected but not roots
                        outgoingShapeIDs = (int[]) currentShape.ConnectedShapes(
                            Microsoft.Office.Interop.Visio.VisConnectedShapesFlags.visConnectedShapesOutgoingNodes,
                            "");

                        if (incomingShapeIDs.Length == 0)
                        {
                            if (outgoingShapeIDs.Length > 0)
                            {
                                // Shape has no incoming connections and at 
                                // least one outgoing connection; add to root 
                                // queue for processing
                                rootShapeIDs.Add(currentShape.ID);
                            }
                        }
                        else if (outgoingShapeIDs.Length > 0)
                        {
                            // Shape has both incoming and outgoing 
                            // connections; add to circuit queue for processing
                            circuitShapeIDs.Add(currentShape.ID);
                        }
                    }
                }

                // Traverse the graph of each root shape found on the page
                foreach (int rootShapeID in rootShapeIDs)
                {
                    if (!processedShapeIDs.Contains(rootShapeID))
                    {
                        TraverseGraph(rootShapeID);
                    }
                }

                // Traverse the graph of each circuit shape found in pageShapes
                System.Diagnostics.Debug.WriteLine("\nProcessing circuits");
                foreach (int circuitShapeID in circuitShapeIDs)
                {
                    if (!processedShapeIDs.Contains(circuitShapeID))
                    {
                        TraverseGraph(circuitShapeID);
                    }
                }
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.Message);
                throw;
            }

            return true;

        }

        /// <summary>
        /// This method does a breadth-first search through a connected directed graph.
        /// </summary>
        /// <param name="rootShapeID">The ID of the shape that the search is started from</param>
        private static void TraverseGraph(int rootShapeID)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("----------");

                // Add root shape to the processing queue
                queuedShapeIDs.Enqueue(rootShapeID);

                while (queuedShapeIDs.Count > 0)
                {
                    int i = queuedShapeIDs.Dequeue();
                    Microsoft.Office.Interop.Visio.Shape currentShape =
                        pageShapes.get_ItemFromID(i);

                    // Process current shape
                    WriteShapeInfo(currentShape, false);
                    processedShapeIDs.Add(i);

                    // Find shapes connected to current shape
                    int[] connectedShapeIDs =
                        (int[]) currentShape.ConnectedShapes(
                            Microsoft.Office.Interop.Visio.VisConnectedShapesFlags.visConnectedShapesOutgoingNodes,
                            "");
                    foreach (int connectedShapeID in connectedShapeIDs)
                    {

                        // Check if connected shape has been processed yet
                        if (!processedShapeIDs.Contains(connectedShapeID))
                        {

                            // If the shape is not yet in the queue, add it to the queue.
                            if (!queuedShapeIDs.Contains(connectedShapeID))
                            {
                                queuedShapeIDs.Enqueue(connectedShapeID);
                            }

                            // The following lines of code examine the 
                            // connector and write its text if necessary. Check
                            // for text on connector between current shape and 
                            // connected shape
                            int[] gluedConnectors =
                                (int[]) currentShape.GluedShapes(
                                    Microsoft.Office.Interop.Visio.VisGluedShapesFlags.visGluedShapesOutgoing1D,
                                    "",
                                    pageShapes.get_ItemFromID(connectedShapeID));

                            Microsoft.Office.Interop.Visio.Shape connector =
                                pageShapes.get_ItemFromID(gluedConnectors[0]);
                            WriteShapeInfo(connector, true);
                        }
                    }
                }
            }

            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.Message);
                throw;
            }
        }

        /// <summary>
        /// This method writes a little bit of information to the debug window to identify the given shape.
        /// </summary>
        /// <param name="shape">The shape to write info about</param>
        /// <param name="isConnector">Whether that shape is a connector.</param>
        public static void WriteShapeInfo(Microsoft.Office.Interop.Visio.Shape shape, bool isConnector)
        {
            int langID = shape.get_CellsU("LangID")
                .get_ResultInt(Microsoft.Office.Interop.Visio.VisUnitCodes.visNoCast, 0 /*fRound*/);
            // If it's a connector, we will indent the shape info.
            string leftPadding = isConnector ? "\t" : "";
            string shapeText = shape.Characters.Text.ToString();
            bool isBlankConnector = isConnector && String.IsNullOrEmpty(shapeText);
            // If it's a blank connector, don't write any info on it.
            if (!isBlankConnector)
            {
                System.Diagnostics.Debug.WriteLine(
                    System.String.Format(CultureInfo.GetCultureInfo(langID),
                        "{0}<text>{1}</text> <ID>{2}</ID>",
                        leftPadding,
                        shapeText,
                        shape.ID));
            }
        }
    }

}